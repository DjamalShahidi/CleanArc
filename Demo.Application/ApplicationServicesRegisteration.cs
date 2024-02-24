using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Demo.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
