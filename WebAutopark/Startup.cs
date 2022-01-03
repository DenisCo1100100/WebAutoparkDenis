using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.Core.Entities;
using WebAutopark.DataBaseAccess.Repository;
using WebAutopark.DataBaseAccess.Repository.Base;
using WebAutopark.DataBaseAccess.Services;

namespace WebAutopark
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConnectionStringProvider, ConnectionStringProvider>();
            services.AddScoped<IRepository<Component>, ComponentRepository>();
            services.AddScoped<IRepository<OrderItem>, OrderItemRepository>();
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();

            services.AddAutoMapper
            (
                cfg =>
                {
                    cfg.CreateMap<Component, ComponentModel>()
                       .ForMember(dest => dest.ComponentId, act => act.MapFrom(src => src.ComponentId))
                       .ReverseMap();

                    cfg.CreateMap<VehicleType, VehicleTypeModel>()
                        .ForMember(dest => dest.VehicleTypeId, act => act.MapFrom(src => src.VehicleTypeId))
                        .ReverseMap();

                    cfg.CreateMap<Vehicle, VehicleModel>()
                        .ForMember(dest => dest.VehicleId, act => act.MapFrom(src => src.VehicleId))
                        .ReverseMap();

                    cfg.CreateMap<OrderItem, OrderItemModel>()
                        .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderId))
                        .ReverseMap();

                    cfg.CreateMap<Order, OrderModel>()
                        .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderId))
                        .ReverseMap();
                }
            );

            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}