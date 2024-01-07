GateGather Backend README
Overview
Welcome to the backend of GateGather, the scheduling app for Baldur's Gate 3 enthusiasts! This backend is built using the .NET framework and utilizes PostgreSQL as the database.

Getting Started
To set up the GateGather backend on your local machine, follow these steps:

Prerequisites
Install .NET on your machine.
Set up a PostgreSQL database.
Configuration
Clone the GateGather repository.

bash
Copy code
git clone https://github.com/your-username/GateGather.git
Navigate to the backend directory.

bash
Copy code
cd GateGather/Backend
Create a configuration file (appsettings.json) and configure your PostgreSQL connection string.

json
Copy code
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=your-host;Port=your-port;Database=your-database;Username=your-username;Password=your-password"
  },
  // Other configurations...
}
Database Migration
Run the following commands to apply the database migrations:

bash
Copy code
dotnet ef migrations add InitialCreate
dotnet ef database update
Running the Application
bash
Copy code
dotnet run
The backend should now be running at http://localhost:5000.

API Documentation
For detailed information on the available API endpoints and their usage, refer to the API documentation.

Contributing
If you'd like to contribute to GateGather, please follow our contribution guidelines.

Issues
If you encounter any issues or have suggestions, please report them on the issue tracker.

License
GateGather is licensed under the MIT License. Feel free to use, modify, and distribute the code as needed.
