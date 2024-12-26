# Bank-System
&emsp;An API built using ASP.NET Core that will be used as the backend side of a bank system.

# Setup
## Easy Mode
1. Clone the repo.
2. Click on "Code" then "Codespaces" to create a new instance. Wait for it to be made ready.
3. Execute the following commands:
    ```bash
    cd Bank-System
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet ef migrations add {any name you want}
    dotnet ef database update
    dotnet run
    ```
    This will setup and run the API along with creating the database file (DB file).
3. Test the API by opening the link from the port menu and test the API in the browser using the provided UI.

## Hard Mode
1. clone the repo.
2. Install [.NET SDK](https://dotnet.microsoft.com/download) (version used: 7.0)
3. Install SQLite (if needed for manual database inspection).
4. Install any dependancy that you might be missing. Know those by running:
    ```bash
    cd Bank-System
    dotnet ef migrations add {Any name you want}
    dotnet ef database update
    dotnet run
    ```
5. Run the after building the database file -DB file- API using:
    ```bash
    cd Bank-System
    dotnet ef migrations add {Any name you want}
    dotnet ef database update
    dotnet run
    ```

# Testing
&emsp; To test the API, there are to ways. The first is through its UI using your browser by opening the link provided in the "Port" tab of VS Code.<br>
&emsp;The other is through Python. You simpley execute the test file for the corrosponding endpoint that you would like to use. For those that used the "Easy Mode Setup", python is already installed on the environment and they should follow those commands:
```bash
cd Bank-System/Tests
python test_{endpoint name}
```
&emsp;The test file will ask for some information relating to said endpoint.<br>
&emsp;For those how are going the hard way, they should install Python on their device and execute the test files for the endpoint they want.

# API Documentation
&emsp;If you wish to know some general information about the endpoints, their use, or their parameters, you can do so from the following [link](https://night-belly-22c.notion.site/API-Docs-Bank-Backend-167507c0fa4580c6b039d0e163852b1e?pvs=4).
