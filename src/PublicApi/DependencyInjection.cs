using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PublicApi.Authentication;
using PublicApi.Configurations;
using System.Text.Json;

namespace PublicApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPublicApi(this IServiceCollection services, IConfiguration configuration)
        {
            var apiKeySetting = configuration
                .GetSection("ApiKeySettings")
                .Get<ApiKeySettings>();

            services.Configure<ApiKeySettings>(configuration.GetSection("ApiKeySettings"));

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                    options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                })
                .AddScheme<ApiKeyAuthenticationOptions, ApiKeyAuthenticationHandler>(ApiKeyAuthenticationOptions.DefaultScheme, null);

            services.AddAuthorization();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "AlzaCaseStudyApi", Version = "v2" });

                c.AddSecurityDefinition(apiKeySetting.ApiKeyHeaderName, new OpenApiSecurityScheme
                {
                    Description = "Api key needed to access the endpoints. X-Api-Key: My_API_Key",
                    In = ParameterLocation.Header,
                    Name = apiKeySetting.ApiKeyHeaderName,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Name = apiKeySetting.ApiKeyHeaderName,
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference 
                            { 
                                Type = ReferenceType.SecurityScheme,
                                Id = apiKeySetting.ApiKeyHeaderName 
                            },
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}
