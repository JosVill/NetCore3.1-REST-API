# NetCore3.1-REST-API

Creación de una REST API en Net Core 3.1 
Para más información visite la web https://dotnet.microsoft.com/en-us/download/dotnet/3.1

## Contenido

1. [Requisitos previos](#requisitos-previos)
2. [Crear proyecto Net Core web API](#create-&-project)
3. [Paquetes Nugget](#dependencias)
4. [Migraciones en NetCore](#migraciones-en-netcore)
5. [Routes](#routes)

## Requisitos previos

- C#

## Crear proyecto Net Core web API

```
  dotnet new webapi -n Commander
```

## Paquetes Nugget

- dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 7.0.0
- dotnet add package Microsoft.AspNetCore.JsonPatch --version 3.1.3
- dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 3.1.3
- dotnet add package Microsoft.EntityFrameworkCore --3.1.3
- dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.3
- dotnet add package Npgsql --version 4.1.10
- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.1.3


## Migraciones en NetCore

Utilizando la herramienta donet ef aka https://docs.microsoft.com/en-us/ef/core/cli/dotnet#:~:text=dotnet%20ef%20can%20be%20installed%20as%20either%20a,a%20tooling%20dependency%20using%20a%20tool%20manifest%20file.
instalar la herramienta

```
dotnet tool install --global dotnet-ef
```
### Realizando las migraciones

Revisar si esta instalada la herramienta de forma global 
```
dotnet ef
```
Realizar la migración
```
dotnet ef migrations add InitialCreate
```
Creación de las tablas e inserción a la base de datos
```
dotnet ef database update
```

## Routes
Test app using Postman REST CLient https://www.postman.com/downloads/  

 - GET    all commands       http://localhost:5000/api/commands
 - GET    command by id      http://localhost:5000/api/commands/id
 - POST   create command     http://localhost:5000/api/commands
 - PUT    update command     http://localhost:5000/api/commands/id
 - DELETE delete command     http://localhost:5000/api/commands

### Other REST Client
https://insomnia.rest/download
https://marketplace.visualstudio.com/items?itemName=humao.rest-client

## What Next
- Instalar y configurar Swagger Web API
- Actualizar a la versión Net Core 6
- Crear un FrontEnd

 





