using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WeatherAPI.Models;


//Below, the Id property is required for mapping the common language runtime (CLR) object to the MongoDB collection. 
//The Id property is annotated with the [BsonId] attribute to designate this property as the document's primary key. 
//The [BsonRepresentation(BsonType.ObjectId)] attribute indicates that the Id property will be represented in MongoDB using an ObjectId.  
//If the Id property is missing from a Book object when it's inserted, MongoDB automatically generates a unique ObjectId value for the property.


public class User
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("Name")]
    
    //the = null syntax automatically sets this variable to null. The ! operator is used in the context of nullable reference types. It tells the compiler 'dont worry, I know what I'm doing' - the compiler will by default warn you if you try to assign null. Reference types are non-nullable by default. 
    public string Name { get; set; } = null!;
    public string UserName { get; set; }
    public string Email { get; set; } = null!;
    public string Password {get; set;} 

    public bool Verified { get; set; } = false;

}