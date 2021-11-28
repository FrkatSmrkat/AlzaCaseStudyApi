# Overview
Simple API to demonstrate asp. net core skills  
Assignment is in this repository on path /documentation/BE_Developer_Case_Study.pdf  

## Used techonologies
ASP.NET 5  
Entity Framework Core 5

## Architecture
Based on Clean Architecture with merging domain into application since we have no domain logic
PublicApi - presentation layer  
Infrastructure - data layer  
ApplicationCore - application logic layer  


## Reference projects
*projects used as  inspiration*  
https://github.com/dotnet/AspNetCore.Docs.git  
https://github.com/dotnet-architecture/eShopOnWeb.git  
https://github.com/ardalis/CleanArchitecture.git  
https://github.com/ardalis/Specification.git  



# Build & Run
Visual studio with .NET 5 installed to build  
Provide connection string to your database in PublicApi/appsettings.json  
From package manager console run Update-database to create and seed database. Choose proper enviroment first (dev/prod).  
Run from .exe in /bin folder or in debug from vs  


# Tests
One integration test in /tests folder.  
Swagger when running in debug


# Shortcomings
ApiKey is not great in general. Storing key in appsettings is bad. But its easy to write and the edit endpoint isnt open.  
Tests .. Only integration tests for get endpoints. No unit tests.  
Database seed should not be in configuration. Only one migration.      
Visual studio does not create folders for soluion folders .. so new items added into root of solution folders are added into root.  