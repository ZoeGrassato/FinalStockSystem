using FinalSystem.Generics;
using FinalSystem.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalSystem.DI
{
    public static class DiRegistration
    {
        public static void RegisterComponents(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
