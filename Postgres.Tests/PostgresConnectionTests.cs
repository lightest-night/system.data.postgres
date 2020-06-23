using System;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.Extensions.Options;
using Shouldly;
using Xunit;

namespace LightestNight.System.Data.Postgres.Tests
{
    public class PostgresConnectionTests
    {
        private readonly IPostgresConnection _sut;

        public PostgresConnectionTests()
        {
            var fixture = new Fixture();
            var options = fixture.Build<PostgresOptions>()
                .Without(o => o.Host)
                .Without(o => o.Port)
                .Without(o => o.Pooling)
                .Without(o => o.Username)
                .Without(o => o.Password)
                .Without(o => o.Database)
                .Do(o =>
                {
                    o.Host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
                    o.Port = Convert.ToInt32(Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432");
                    o.Pooling = Convert.ToBoolean(Environment.GetEnvironmentVariable("POSTGRES_POOLING") ?? "False");
                    o.Username = Environment.GetEnvironmentVariable("POSTGRES_USERNAME") ?? "postgres";
                    o.Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "postgres";
                    o.Database = Environment.GetEnvironmentVariable("POSTGRES_DATABASE") ?? "postgres";
                })
                .Create();

            _sut = new PostgresConnection(Options.Create(options));
        }
        
        [Fact, Trait("Category", "Unit")]
        public void ShouldBuildNewConnection()
        {
            // Act
            var result = _sut.Build();
            
            // Assert
            result.ConnectionString.ShouldNotBeNullOrEmpty();
            result.ConnectionString.ShouldNotBeNullOrWhiteSpace();
        }

        [Fact, Trait("Category", "Integration")]
        public void ShouldConnectSuccessfully()
        {
            // Act
            using var result = _sut.Build();
            
            // Assert
            Should.NotThrow(() => result.Open());
        }
    }
}