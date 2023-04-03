## Prerequisite
- [Download .NET 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
  - And the latest Visual Studio / VS Code


## Features
- Use NET 7 for Web Applications
- Use Built-In Microsoft ConfigurationBuilder to config (appsettings.json)
- Follow HTTP Status Code for 2xx, 3xx, 4xx
- Async for HTTP communications
- Use Built-In Microsoft OpenAPI for Swagger UI
- Use Built-In HealthCheck (~/health)
- Switch deployment environment by runtime system environment variable
  - ASPNETCORE_ENVIRONMENT: **Development**
- Use xUnit UnitTest Projects  


## Projects
### DemoSite

- Environment Variables
  - **ASPNETCORE_ENVIRONMENT**: ex: `Development`

Scripts
```
$env:ASPNETCORE_ENVIRONMENT = 'Development'
dotnet run --project src/DemoSite/DemoSite.csproj
```

Logs
```
Building...
Hosting environment: Development
Content root path: ./src/DemoSite
Now listening on: http://localhost:5250
Application started. Press Ctrl+C to shut down.
```


## Tests
### UnitTest

- Environment Variables
  - **ASPNETCORE_ENVIRONMENT**: ex: `Development`

Scripts
```
$env:ASPNETCORE_ENVIRONMENT = 'Development'
dotnet test tests/UnitTest/UnitTest.csproj -c Release
```

Logs
```
Determining projects to restore...
  All projects are up-to-date for restore.
  DemoSite -> ./src/DemoSite/bin/Release/net7.0/DemoSite.dll
  UnitTest -> ./tests/UnitTest/bin/Release/net7.0/UnitTest.dll
Test run for ./tests/UnitTest/bin/Release/net7.0/UnitTest.dll (.NETCoreApp,Version=v7.0)
Microsoft (R) Test Execution Command Line Tool Version 17.5.0 (x64)
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:    12, Skipped:     0, Total:    12, Duration: 265 ms - UnitTest.dll (net7.0)
```
