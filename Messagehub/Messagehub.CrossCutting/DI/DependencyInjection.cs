using Messagehub.Domain.Interfaces.Repositories;
using Messagehub.InfraData.Data;
using Messagehub.InfraData.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Messagehub.CrossCutting.DI
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            builder.Services.AddScoped<IMongoDbContext, MongoDbContext>();
            builder.Services.AddScoped<IAccountRepository, AccountRepository>();

        }
    }
}
