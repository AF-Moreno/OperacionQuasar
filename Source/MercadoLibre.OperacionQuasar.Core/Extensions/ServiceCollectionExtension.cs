using MercadoLibre.OperacionQuasar.Core.DataAccess;
using MercadoLibre.OperacionQuasar.Core.Domain;
using MercadoLibre.OperacionQuasar.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace MercadoLibre.OperacionQuasar.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterCoreComponents(this IServiceCollection services)
        {
            services.RegisterDataAccess();
            services.RegisterRepositories();
            services.RegisterDomains();
        }

        public static void RegisterDomains(this IServiceCollection services)
        {
            var toRegister = new List<Tuple<Type, Type>>() {
                new Tuple<Type, Type>(typeof(ITopSecretDomain), typeof(TopSecretDomain)),
                new Tuple<Type, Type>(typeof(IUserDomain), typeof(UserDomain))
            };

            RegisterAllServiceTypeImplementations<IDomain>(services, toRegister);
        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            var toRegister = new List<Tuple<Type, Type>>() {
                new Tuple<Type, Type>(typeof(ISatelliteRepository), typeof(SatelliteRepository)),
                new Tuple<Type, Type>(typeof(IUserRepository), typeof(UserRepository))
            };

            RegisterAllServiceTypeImplementations<IRepository>(services, toRegister);
        }

        public static void RegisterDataAccess(this IServiceCollection services)
        {
            services.AddScoped<ISqlDataAccess, SqlDataAccess>();
        }

        private static void RegisterAllServiceTypeImplementations<T>(this IServiceCollection services, IEnumerable<Tuple<Type, Type>> toRegister)
        {
            var serviceType = typeof(T);

            foreach (var reg in toRegister)
            {
                if (serviceType.IsAssignableFrom(reg.Item1))
                {
                    services.AddTransient(reg.Item1, reg.Item2);
                }
            }
        }
    }
}