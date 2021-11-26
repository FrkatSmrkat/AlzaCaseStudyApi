using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Services;
using ApplicationCore.Services.Abstractions;
using ApplicationCore.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ApplicationCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ProductSettings>(configuration.GetSection("ProductSettings"));
            services.AddScoped<IProductService, ProductService>();
            services.AddSingleton<IUriService, UriService>();
            return services;
        }
    }
}
