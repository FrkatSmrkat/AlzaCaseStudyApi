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

Application layer does not have references to any other project  
Domain layer would contain

## Reference projects
https://github.com/dotnet/AspNetCore.Docs.git  
https://github.com/dotnet-architecture/eShopOnWeb.git  
https://github.com/ardalis/CleanArchitecture.git  
https://github.com/ardalis/Specification.git  



# Build & Run



# Tests



# Shortcomings
No authorization/authentication  
Low test coverage  
visual studio does not create folders for soluion folders .. so new items added into root of solution folders are added into root