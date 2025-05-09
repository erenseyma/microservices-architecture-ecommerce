using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Catalog.Entities
{
    public class Category
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; } //mongo da ilişkili olmadığı için int değl string kullnadık
        public string CategoryName { get; set; }
    }
}
