using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Services;
using ApplicationCore.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            //TODO: probably options builder for uriService
            services.AddSingleton<IUriService, UriService>();
            return services;
        }
    }
}
