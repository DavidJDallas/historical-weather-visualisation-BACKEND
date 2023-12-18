using DataStoreApi.Models;

public class Startup
{
    private readonly string connectionString;

    public Startup()
    {
        connectionString = Environment.GetEnvironmentVariable("WEATHER_SERVER_DB_CONNECTION_STRING");


    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<DatabaseSettings>(options =>
        {
             options.ConnectionString = Environment.GetEnvironmentVariable("WEATHER_SERVER_DB_CONNECTION_STRING") ??
                                       "mongodb://localhost:27017/default-connection-string";

            Console.WriteLine(options.ConnectionString);

        }
        );
    }
}