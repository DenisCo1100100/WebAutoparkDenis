using Microsoft.Extensions.DependencyInjection;
using WebAutopark.BusinessLogic.DataTransferObject;
using WebAutopark.BusinessLogic.Services;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark.BusinessLogic.Extensoins
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddScoped<IRepository<Component>, ComponentRepository>();
            services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();

            return services;
        }

        public static IServiceCollection AddDtoServices(this IServiceCollection services)
        {
            services.AddScoped<IDataService<ComponentDto>, ComponentService>();
            services.AddScoped<IDataService<VehicleDto>, VehicleService>();
            services.AddScoped<IDataService<VehicleTypeDto>, VehicleTypeService>();

            return services;
        }
    }
}