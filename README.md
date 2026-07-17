# Smart Asset Tracking System

## Overview

Smart Asset Tracking System is a console-based application developed in C# for managing company assets. The system allows users to add, update, delete, and view assets stored in a MySQL database using Entity Framework Core.

The application supports different asset types through inheritance and provides reports for asset management, including asset counts, total values, expiring assets, and the most expensive assets.

## Features

### Asset Management (CRUD)

The system supports:

- Displaying all assets
- Adding new assets
- Updating existing assets
- Deleting assets

Supported asset types:

- Computer
- Mobile Phone

### Object-Oriented Design

The project uses inheritance:

- `Asset` is an abstract base class
- `Computer` inherits from `Asset`
- `MobilePhone` inherits from `Asset`

Common asset properties include:

- Brand
- Model
- Purchase date
- Price
- Office location
- Currency
- Serial number
- Assigned employee
- Warranty expiration date

## Database

The application uses:

- Entity Framework Core
- MySQL database
- Code First approach
- Migrations

The database contains an `Assets` table with inheritance handled using a discriminator column.

## Seed Data

The project includes initial seed data so that the database contains example assets when the application is set up.

Seeded examples include:

- Computers from different offices
- Mobile phones from different offices, including Turkey

## Reports

The system includes the following reports:

### Asset Count Per Office

Displays how many assets exist in each office.

### Total Value Per Office

Calculates the total value of assets in each office using local currency conversion.

Supported currencies:

- SEK
- USD
- EUR
- TRY

### Expiring Assets

Displays assets that are close to reaching their end-of-life status.

Asset status levels:

- GREEN - More than 180 days remaining
- YELLOW - Less than 180 days remaining
- RED - Less than 90 days remaining

### Most Expensive Assets

Displays the top 5 most expensive assets based on purchase price.

## Requirements

Before running the project, make sure you have:

- .NET SDK installed
- MySQL server running
- Correct database connection settings

## Database Setup

This project uses **MySQL** with **Entity Framework Core Code First**.

### Requirements

Before running the project, install:

- .NET SDK
- MySQL Server
- Entity Framework Core tools

### 1. Configure the Database Connection

Open:

```
appsettings.json
```

Update the connection string to match your own MySQL setup:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=AssetTracking;User=YOUR_USERNAME;Password=YOUR_PASSWORD"
  }
}
```

Replace:

- `YOUR_USERNAME` with your MySQL username
- `YOUR_PASSWORD` with your MySQL password
- `localhost` if your MySQL server is located somewhere else

### 2. Create the Database

The project uses migrations. To create/update the database, run:

```
dotnet ef database update
```

This will:

- Create the `AssetTracking` database
- Create the required tables
- Apply all migrations

### 3. Seed Data

The project includes seed data using Entity Framework Core `HasData()`.

After running the database update command, the database will automatically contain example assets, including:

- Computers
- Mobile phones
- Different offices
- Assigned employees
- Warranty dates

### 4. Run the Application

Start the application with:

```
dotnet run
```

The application will open the Smart Asset Tracking System menu.

## Database Note

This project was developed using:

- MySQL
- Entity Framework Core
- Visual Studio Code

The project is configured for MySQL. If another database provider is used (for example Microsoft SQL Server), the EF Core provider, connection string, and migrations must be changed accordingly.

## Menu Options

The application provides:

```
1. Show all assets
2. Add asset
3. Update asset
4. Delete asset
5. Show reports
6. Exit
```

## Technologies Used

- C#
- .NET
- Entity Framework Core
- MySQL
- LINQ
- Object-Oriented Programming

## Project Structure

```
AssetTrackingSystem
│
├── Asset.cs              # Base class and derived asset classes
├── MyDbContext.cs        # Database context and seed data
├── Program.cs            # Application logic and menu
├── Migrations/           # EF Core database migrations
├── appsettings.json      # Database configuration
└── README.md
```

## Author

Created as part of a C# / Entity Framework Core assignment.

## Assignment Progress

### Completed Levels

The current version of the Smart Asset Tracking System includes:

- ✅ Level 1: Basic asset management functionality
- ✅ Level 2: Database integration using Entity Framework Core and MySQL
- ✅ Level 3: Advanced functionality including inheritance, reports, LINQ queries, and seed data

### Future Improvements

The project can be extended further with additional challenges:

- Level 4: Additional improvements and advanced functionality
- Level 5: Further enhancements and more complex features

These levels are planned as future improvements to continue developing the system and exploring more advanced C# and Entity Framework Core concepts.
