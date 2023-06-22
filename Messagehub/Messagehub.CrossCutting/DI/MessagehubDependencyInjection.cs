using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Messagehub.CrossCutting.DI
{
    public static class MessagehubDependencyInjection
    {
        public static void AddMessagehubDependencyInjection(this WebApplicationBuilder builder)
        {
            builder.Services.AddSignalR();
        }
    }
}
