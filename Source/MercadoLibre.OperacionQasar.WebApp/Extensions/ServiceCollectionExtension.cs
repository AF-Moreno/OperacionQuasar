using MercadoLibre.OperacionQasar.WebApp.Filters;
using MercadoLibre.OperacionQuasar.Core.DataAccess;
using MercadoLibre.OperacionQuasar.Core.Domain;
using MercadoLibre.OperacionQuasar.Core.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MercadoLibre.OperacionQasar.WebApp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddBasicAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(Constants.BASIC_AUTHENTICATION_SCHEMA)
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(Constants.BASIC_AUTHENTICATION_SCHEMA, null);
        }
    }
}