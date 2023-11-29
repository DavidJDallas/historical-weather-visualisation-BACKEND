using DataStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

//A services directory is used to organise and contain classes that provide various services or business logic for the app. E.g. interacting with databases, performing calculations, handling specific aspects. 
//The service file here interacts with a MongoDB database to perform CRUD operations. 
//Models define the structure of the data, whereas services handles the logic for interacting with external resources, e.g. the Mongo database. 

//Models focus on the data representation, and services handle the data access and manipulation logic.


namespace DataStoreApi.Services;

public class DataService
{
    private readonly IMongo
}