using ICut.Domain.Interfaces;
using ICut.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ICut.CrossCutting.DI
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITokenService, TokenService>();
        }
    }
}
