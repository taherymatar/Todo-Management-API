# Todo-Management-API

A simple ASP.NET Core 8 for Todo Management API.

## 🔧 Technologies

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Bootstrap (for front-end styling)

## 🚀 Getting Started

### Prerequisites
Before you begin, make sure you have the following installed:
- .NET 8 SDK
- SQL Server
- Visual Studio

### Setup Instructions
Follow these steps to run the project locally:
1. Clone or download the repository
Clone the repository using Git or download it as a ZIP file.

2. Set your connection string in `appsettings.json`.
In appsettings.json, configure your database connection string:
`"ConnectionStrings": {
  "DefaultConnection": "Your_Connection_String_Here"
}
`.
3. Run Database Migrations
Open the Package Manager Console in Visual Studio and run the following commands to apply database migrations:
`add-migration InitialCreate
update-database`
4. Run the Project
You can run the project using one of the following methods:
- Use dotnet run from the terminal (navigate to the project directory first)
- Or press F5 or click Run in Visual Studio to use IIS Express.
    
Ensure you replace the connection string in appsettings.json before running the project.
