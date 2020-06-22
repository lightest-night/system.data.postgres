using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LightestNight.System.Data.Postgres
{
    public static class ExtendsServiceCollection
    {
        public static IServiceCollection AddPostgresData(this IServiceCollection services,
            Action<PostgresOptions>? optionsAccessor = null)
        {
            services.ConfigureOptions(optionsAccessor);
            services.TryAddSingleton<IPostgresConnection, PostgresConnection>();

            return services;
        }
    }
}