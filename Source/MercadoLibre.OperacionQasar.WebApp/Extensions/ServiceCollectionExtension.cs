namespace MercadoLibre.OperacionQasar.WebApp.Extensions
{
    using MercadoLibre.OperacionQasar.WebApp.Filters;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;

    public static class ServiceCollectionExtension
    {
        public static void AddBasicAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(Constants.BASIC_AUTHENTICATION_SCHEMA)
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(Constants.BASIC_AUTHENTICATION_SCHEMA, null);
        }

        public static void AddSwaggerDocumentConfing(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Operacion-Fuego-Quasar-Service", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }
    }
}
