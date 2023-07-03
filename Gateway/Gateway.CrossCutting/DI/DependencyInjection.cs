using FluentValidation;
using Gateway.Domain.DTOs.Request;
using Gateway.Domain.ExternalServices;
using Gateway.Domain.Interfaces.Repositories;
using Gateway.Domain.Interfaces.Services;
using Gateway.Domain.Services;
using Gateway.Domain.Validators;
using Gateway.InfraData.Data;
using Gateway.InfraData.Repositories;
using ICut.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.CrossCutting.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this WebApplicationBuilder builder)
        {
            // HTTP
            builder.Services.AddHttpClient();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200", "https://55b3-2804-431-c7fd-2c24-d87f-9305-4269-c294.ngrok-free.app")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });


            builder.Services.AddTransient<IValidator<AccountRequestDTO>, AccountRequestValidator>();
            builder.Services.AddScoped(typeof(IEventHubExternalService<>), typeof(EventHubExternalService<>));
            builder.Services.AddScoped<IAuthService, AccountService>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
        }
    }
}
