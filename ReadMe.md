
# pildoraXUnit

Simple Web API project with Entity Framework Core & Console App project with their respective Unit Testing xUnit projects to explain how to test Web API with Clean Code, SOLID principles and Pattern Repository design pattern.

## Installation

Nuggets dependencies should being installed automatically when opening solution into your IDE (my case Jetbrains Rider), either way, you have your nuggets list dependencies into your project file on each project.
1. Create docker with SQLServer. Config your respective database, user & password for accessing it.


2. Install Secret Manager tool if you don't have it yet installed globally on your system for using user secrets on your development environment.

      dotnet tool install --global dotnet-user-secrets


3. Create your user secret password with your Secret Manager dotnet tool.

      dotnet user-secrets set "SecretManager:DbPassword" "<your-dbpassword-value>"


4. Config your respective database name, user into *appsettings.Development.json* with your ConnectionString for later using on DbContext.


        "ConnectionStrings": {
            "DefaultConnection": "Server=localhost,1433;Database=APIxUnit;User=sa;TrustServerCertificate=True"
        },


5. Insert your password with User Secret into "DefaultConnection" connectionString and use it to connect with your Database in DbContext.
   I set provider services into Startup.cs, but you can do it too into Program.cs.
   Simply make sure that your user secret corresponds with ["SecretSection:DbPassword"]. If not, change that value with your user secret created previously.

      ### *Startup.cs*

          services.AddDbContext<AppDbContext>(options =>
          {
              // Setup String connection with password env data
              var conStrBuilder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));
              conStrBuilder.Password = Configuration["SecretSection:DbPassword"];
              var connection = conStrBuilder.ConnectionString;
              options.UseSqlServer(connection);
          });

6. Try running your APIApp: http project. If swagger works and you get status code 200, you are fine.


7. Run tests with your IDE and just play with existing tests and try to create new tests and extend APIApp or ConsoleApp functionalities for testing even more complex code.