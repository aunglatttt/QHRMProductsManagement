# QHRMProductsManagement

A simple ASP.NET Core web application for managing products with CRUD operations using Dapper and SQL Server.

## Features

- List all products with pagination
- Add new products
- Edit existing products
- Delete products
- Responsive design with Bootstrap 5

## Prerequisites

- .NET 8 SDK
- SQL Server

## Setup

1. Clone the repository
2. Create a database in SQL Server using the script provided 'QHRMProductsDB.sql'
   - You can find the script in the `Database` folder of this repository.
   - Run the script in SQL Server Management Studio
3. Update the connection string in `appsettings.json`
4. Run the application

## Running the Application

```bash
dotnet run


