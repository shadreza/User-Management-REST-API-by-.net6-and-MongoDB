using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagement.Models

{
    [BsonIgnoreExtraElements]
    public class User
    {   
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]         
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("married")]
        public bool Married { get; set; }
    }
}
