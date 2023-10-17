using WeatherAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WeatherAPI.Services;


//A bookstoredatabase settings instance is retrieved from the dependency injection via constructor injection. This technique provides access to the appsettings.json configuration values that were added in the Add a configuration model section. 
public class UsersService
{
    private readonly IMongoCollection<User> _usersCollection;

    public UsersService(     
        IOptions<WeatherAPI.Models.WeatherServerDatabaseSettings> weatherServiceDatabaseSettings
        )
    {
        var mongoClient = new MongoClient(
            weatherServiceDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            weatherServiceDatabaseSettings.Value.DatabaseName);

        _usersCollection = mongoDatabase.GetCollection<User>(
            weatherServiceDatabaseSettings.Value.UsersCollectionName);
    }

    //A task represents some asynchronous operation and is part of the Task Parallel library, which is a set of APIs for running tasks asynchronously and in parallel. 
    public async Task<List<User>> GetAsync(){       
        return await _usersCollection.Find(_ => true).ToListAsync();
    }
        

    public async Task<User?> GetAsync(string id) =>
        await _usersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newUser) =>
        await _usersCollection.InsertOneAsync(newUser);

    public async Task UpdateAsync(string id, User updatedUser) =>
        await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

    public async Task RemoveAllAsync() =>
        await _usersCollection.DeleteManyAsync(FilterDefinition<User>.Empty);
}

