# pokedex
Pokemon information service

# how to build and run

1. Install dotnet 6 SDK (https://dotnet.microsoft.com/en-us/download).
2. dotnet build to restore nuget packages and build code.
3. Navigate to 'Pokedex.Api' directory.
4. dotnet run to run application.
5. Swagger UI available (https://localhost:7146/swagger/index.html).


# production consideration

1. In production I would add some sort of logging (I user Azure app insights currently) to help diagnose issues.
2. Add authentication
3. Use caching so we don't hit rate limits as quickly when using third-party api.

