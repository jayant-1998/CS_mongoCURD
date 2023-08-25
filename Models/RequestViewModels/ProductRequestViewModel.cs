using MongoDB.Bson.Serialization.Attributes;

namespace ProductsWithMongo.Models.RequestViewModels
{
    public class ProductRequestViewModel
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
    }
}
