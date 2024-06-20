using APIApp.Data;
using APIApp.Repositories.Project;
using APIApp.Repositories.User;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace APIApp;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            // Setup String connection with password env data
            var conStrBuilder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));
            conStrBuilder.Password = Configuration["SecretSection:DbPassword"];
            var connection = conStrBuilder.ConnectionString;
            options.UseSqlServer(connection); 
        });
        
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        services.AddAutoMapper(typeof(Startup));

        services.AddControllers();
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}