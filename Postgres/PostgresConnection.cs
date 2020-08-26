using System;
using Npgsql;

namespace LightestNight.System.Data.Postgres
{
    public class PostgresConnection : IPostgresConnection
    {
        private readonly PostgresOptions _options;

        public PostgresConnection(PostgresOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <inheritdoc cref="Build" />
        public NpgsqlConnection Build()
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = _options.Host,
                Port = _options.Port,
                Database = _options.Database,
                Username = _options.Username,
                Password = _options.Password,
                SslMode = _options.SslMode,
                TrustServerCertificate = _options.TrustServerCertificate,
                ServerCompatibilityMode = _options.ServerCompatibilityMode,
                Timeout = _options.ConnectionTimeout,
                CommandTimeout = _options.CommandTimeout,
                Pooling = _options.Pooling,
                MinPoolSize = _options.MinPoolSize,
                MaxPoolSize = _options.MaxPoolSize,
                ConnectionPruningInterval = _options.ConnectionPruningInterval
            };
    
            return new NpgsqlConnection(builder.ConnectionString);
        }
    }
}