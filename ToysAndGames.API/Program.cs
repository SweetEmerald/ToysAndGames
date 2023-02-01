using Microsoft.EntityFrameworkCore;
using Serilog;
using ToysAndGames.API.Infrastructure;
using ToysAndGames.Data;
using ToysAndGames.Services.Interfaces;
using ToysAndGames.Services.Services;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    const string AllowLocalhostCORSPolicy = "AllowLocalhostCORSPolicy";

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: AllowLocalhostCORSPolicy,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                          });

    });

    var connectionString = builder.Configuration.GetConnectionString("ToysAndGamesDB");
    var container = builder.Services.AddDbContext<ToysAndGamesDbContext>(option => option.UseSqlServer(connectionString));

    // Add services to the container.
    builder.Services.AddControllers();

    builder.Services.ConfigureMapperProfiles();

    //Add Dependency Injection services
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<ICompanyService, CompanyService>();
    builder.Services.AddScoped<IFileStorage, FileStorageLocal>();
    builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetService<ToysAndGamesDbContext>();
            db?.Database.Migrate();
        }
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    
    app.UseStaticFiles();

    app.UseCors(AllowLocalhostCORSPolicy);

    app.UseAuthorization();

    app.MapControllers();
    app.MapGet("/", () => "ToysAndGames.API");

    app.Run();
}
catch (Exception ex) when (ex.GetType().Name == "StopTheHostException" || ex.GetType().Name == "HostAbortedException")
{
    Log.Information("Migration exception, all is well in the world.");
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
