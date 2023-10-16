using WeatherAPI.Models;
using WeatherAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<WeatherServerDatabaseSettings>(
    builder.Configuration.GetSection("WeatherServerDatabase")
);
//Directly above, the configuration instance to which the appsettings.json file's WeatherServerDatabase section binds is registered in the Dependency Injection container. 
//Binding here means that the IConfiguration object (builder.Configuration) will have a WeatherServerDatabase property with the same properties as the appsettings.json file's WeatherServerDatabase section.

builder.Services.AddSingleton<UsersService>();
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
