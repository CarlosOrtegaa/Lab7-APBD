\# Tutorial 7 - APBD



REST API for managing computers and components using ASP.NET Core Web API and Entity Framework Core Code First.



\## Technologies



\- ASP.NET Core Web API

\- Entity Framework Core

\- SQLite

\- Code First migrations

\- Swagger



\## Implemented endpoints



\- GET /api/pcs

\- GET /api/pcs/{id}/components

\- POST /api/pcs

\- PUT /api/pcs/{id}

\- DELETE /api/pcs/{id}



\## Project structure



\- Controllers - API endpoints

\- Services - business logic

\- DTOs - request and response objects

\- Models - database entities

\- Data - Entity Framework Core database context

\- Migrations - EF Core migrations



\## Database



The database structure is created using Entity Framework Core migrations.



Seed data is included for:



\- PCs

\- Components

\- Component manufacturers

\- Component types

\- PC-component relationships



The local SQLite database file is not included in the repository. It can be generated using EF Core migrations.



\## How to run



```bash

dotnet restore

dotnet build

dotnet ef database update

dotnet run


