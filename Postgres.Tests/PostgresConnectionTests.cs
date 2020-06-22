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
            var options = fixture.Create<PostgresOptions>();

            _sut = new PostgresConnection(Options.Create(options));
        }
        
        [Fact]
        public void ShouldBuildNewConnection()
        {
            // Act
            var result = _sut.Build();
            
            // Assert
            result.ConnectionString.ShouldNotBeNullOrEmpty();
            result.ConnectionString.ShouldNotBeNullOrWhiteSpace();
        }
    }
}