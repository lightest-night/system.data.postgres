using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LightestNight.System.Data.Postgres
{
    public static class ExtendsServiceCollection
    {
        public static IServiceCollection AddPostgresData(this IServiceCollection services,
            Action<PostgresOptions>? options = null)
        {
            var postgresOptions = new PostgresOptions();
            options?.Invoke(postgresOptions);

            services.TryAddSingleton<IPostgresConnection>(_ => new PostgresConnection(postgresOptions));

            return services;
        }
    }
}