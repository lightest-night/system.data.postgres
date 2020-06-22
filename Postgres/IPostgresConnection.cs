using Npgsql;

namespace LightestNight.System.Data.Postgres
{
    public interface IPostgresConnection
    {
        /// <summary>
        /// Builds an <see cref="NpgsqlConnection" /> based on the known options
        /// </summary>
        /// <returns>A ready to use, but closed, <see cref="NpgsqlConnection" /></returns>
        NpgsqlConnection Build();
    }
}