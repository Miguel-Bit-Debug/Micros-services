using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Domain.Interfaces;
using Product.Domain.Services;
using Product.InfraData.Data;
using Product.InfraData.Repositories;
using System.Reflection;

namespace Product.Lambda
{
    public static class Startup
    {
        public static ServiceProvider Services { get; private set; }

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .AddEnvironmentVariables()
                .AddJsonFile($"appsettings.json")
                .Build();

            services.AddSingleton<IConfiguration>(configuration);
            services.AddTransient<IMongoDbContext, MongoDbContext>();
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IProductService, ProductService>();

            Services = services.BuildServiceProvider();
        }
    }
}
