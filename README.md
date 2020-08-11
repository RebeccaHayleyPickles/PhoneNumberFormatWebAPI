# PhoneNumberFormatWebAPI
Web API to edit phone numbers into user recognisable format

- Phone number formatting code in PhoneNumberFormatAPI/Models/PhoneNumberItem.cs

# Software / Installs / Extensions
- MacOS Catalina v10.15.5
- Visual studio code v1.47.3
- C# for visual studio v1.22.1
- .NET SDK from https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/install
- Postman v7.30.0 from https://www.postman.com/downloads/  // To test web api

# Actions
- $dotnet new webapi -n PhoneNumberFormatAPI  // Create WebApi template
- $dotnet add package Microsoft.EntityFrameworkCore.SqlServer  // Adds NuGet packages
- $dotnet add package Microsoft.EntityFrameworkCore.InMemory

- Add Models Folder with PhoneNumberItem class and PhoneNumberContext class
- Register the Database Context and Specify that the database context uses an in-memory database in startup.cs

- $dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design // Adds NuGet packages required for scaffolding
- $dotnet add package Microsoft.EntityFrameworkCore.Design
- $dotnet tool install --global dotnet-aspnet-codegenerator  // Installs the scaffolding engine (dotnet-aspnet-codegenerator)
- $dotnet aspnet-codegenerator controller -name PhoneNumberItemsController -async -api -m PhoneNumberItem -dc PhoneNumberContext -outDir Controllers  //   Scaffolds the PhoneNumber ItemsController

# Run
$dotnet run --project ${PWD}/PhoneNumberFormatAPI.csproj // Hosts at https://localhost:5001

# Test
- Postman v7.30.0 from https://www.postman.com/downloads/
- POST to https://localhost:5001/api/PhoneNumberItems
- GET from https://localhost:5001/api/PhoneNumberItems/{ID}
- Format input in JSON: {"PhoneNumber": "+441234567890"}


