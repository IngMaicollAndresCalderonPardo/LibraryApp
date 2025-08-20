# LibraryApp 📚

A simple **ASP.NET Core MVC** application with an in-memory CRUD and sample **SQL Server scripts** for database design.

## Features
### ASP.NET Core MVC
- Basic CRUD operations (Create, Read, Update, Delete).
- In-memory data storage (no real database connection).
- Clean Bootstrap-based UI.
- Server-side and client-side validation.

### Database Scripts (`bd/` folder)
- `01_create_tables.sql`: shows how to create the **Users** and **Publications** tables, including:
  - `NOT NULL` constraints
  - `UNIQUE` constraints
  - Foreign key with `ON DELETE CASCADE`
  - `CHECK` constraints for data validation
- `02_insert_data.sql`: inserts sample data into the tables.

⚠️ **Note:** The SQL scripts are **not connected** to the .NET application.  
They are provided as an example of how the schema could be built.  
If you want to connect the application to SQL Server, you would need to:
1. Add a proper connection string in `appsettings.json`.
2. Configure **Entity Framework Core** or ADO.NET.
3. Modify the CRUD logic to work with the database instead of in-memory storage.

---

## Getting Started (In-Memory CRUD)
1. Clone this repository.
2. Open the solution in Visual Studio / VS Code.
3. Run the project:
   ```bash
   dotnet run
