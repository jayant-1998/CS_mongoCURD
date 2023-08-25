using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductsWithMongo.DAL.Entities
{
    public class Product
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ProductName")]
        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int ProductPrice { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Set default value

        public DateTime? ModifiedAt { get; set; } = null; // Default to null

        public DateTime? DeletedAt { get; set; } = null; // Default to null

        public bool IsDeleted { get; set; }
    }
}
