namespace WeatherAPI.Models;

public class WeatherServerDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string UsersCollectionName { get; set; } = null!;
}

//This is used to store the appsettings.json file's BookstoreDatabse property values. The JSON and C# property names are named identically to ease the mapping process.