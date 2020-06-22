# Lightest Night
## Data > Postgres

Postgres SQL Data Components

### Build Status
![](https://github.com/lightest-night/system.data.postgres/workflows/CI/badge.svg)
![](https://github.com/lightest-night/system.data.postgres/workflows/Release/badge.svg)

#### How To Use
##### Registration
* Asp.Net Standard/Core Dependency Injection
  * Use the provided `services.AddPostgresData(Action<PostgresOptions> optionsAccessor = null)` method

* Other Containers
  * Register the `PostgresOptions` as an instance of `IOptions<PostgresOptions>`.
  * Register `IPostgresConnection` as a Singleton. `PostgresConnection` has been provided for this use case
  
##### Usage
* `NpgsqlConnection Build()`
  * A function to call to generate a new, ready to use, but closed, instance of `NpgsqlConnection`