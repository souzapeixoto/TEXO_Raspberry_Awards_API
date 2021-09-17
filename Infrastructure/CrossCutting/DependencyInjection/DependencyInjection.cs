using Application;
using Application.Interface;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infrastructure.CrossCutting.UnitOfWork.Interface;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.CrossCutting.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryMovie, RepositoryMovie>();
            services.AddScoped<IRepositoryStudio, RepositoryStudio>();
            services.AddScoped<IRepositoryProducer, RepositoryProducer>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<IAppServiceGoldenRaspberryAwards, AppServiceGoldenRaspberryAwards>();
            services.AddScoped<IServiceGoldenRaspberryAwards, ServiceGoldenRaspberryAwards>();
            return services;
        }
    }
}
