using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataStoreApi.Models;

public class Data
{
    //Bson - Binary JSON. MongoDB stores data in BSON Format both internally and over the network, but you can think of MongoDB as a JSON database. Anything that can be represented in JSON can be natively stored in MongoDB and retrieved just as easily in JSON. 
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }   
    
    [BsonElement("Name")]
    public string Date {get; set;} = null!;
    public float Rain {get; set;}
    public float TemperatureMax {get; set;}

}