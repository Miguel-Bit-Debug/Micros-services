using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Product.Domain.DTOs.Request;
using Product.Domain.ExternalService;
using Product.Domain.Interfaces;
using Product.Domain.Validators;
using System.Text;

namespace Product.CrossCutting.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this WebApplicationBuilder builder)
        {

            var key = Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"]);

            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = builder.Configuration["Audience"],
                    ValidIssuer = builder.Configuration["Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Validators
            builder.Services.AddTransient<IValidator<ProductRequestDTO>, ProductRequestValidator>();

            // HTTP CLIENT
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Services
            builder.Services.AddScoped(typeof(IEventHubExternalService<>), typeof(EventHubExternalService<>));
            builder.Services.AddScoped<IProductCacheExternalService, ProductCacheExternalService>();

        }
    }
}
