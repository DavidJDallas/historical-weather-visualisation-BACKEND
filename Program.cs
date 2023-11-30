using DataStoreApi.Models;
using DataStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("WeatherServerDatabase"));

//Below the DataService Class is registered with depdency injection to support constructor injection in consuming classes.
builder.Services.AddSingleton<DataService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Directly above, the configuration instance to which the appsettings.json file's WeatherServerDatabase section binds is registered in the Dependency Injection container. 
//Binding here means that the IConfiguration object (builder.Configuration) will have a WeatherServerDatabase property with the same properties as the appsettings.json file's WeatherServerDatabase section.

//Above registers a UsersService instance with the Dependency Injection container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
