using MongoDB.Driver;
using ProductsWithMongo.DAL.Entities;
using ProductsWithMongo.DAL.Repos.Interfaces;
using ProductsWithMongo.Extensions;
using ProductsWithMongo.Models.RequestViewModels;

namespace ProductsWithMongo.DAL.Repos.Implementations
{
    public class ProductRepo : IProductRepo
    {
        private readonly IMongoCollection<Product> productCollection;
        private readonly IConfiguration _configuration;
        public ProductRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
            var mongoClient = new MongoClient(_configuration["ProductDatabase:ConnectionString"]);
            var mongoDatabase = mongoClient.GetDatabase(_configuration["ProductDatabase:DatabaseName"]);
            productCollection = mongoDatabase.GetCollection<Product>(_configuration["ProductDatabase:ProductCollectionName"]);
        }

        public async Task<List<Product>> ProductListAsync()
        {
            return await productCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Product> GetProductDetailByIdAsync(string productId)
        {
            return await productCollection.Find(x => x.Id.Equals(productId) && !x.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<Product?> AddProductAsync(ProductRequestViewModel productDetails)
        {
            var product = productDetails.ToViewModel<ProductRequestViewModel, Product>();
            await productCollection.InsertOneAsync(product);
            return product;
        }

        public async Task<UpdateResult> UpdateProductAsync(string productId, UpdateRequestViewModel details)
        {
            var update = Builders<Product>.Update
                .Set(x => x.ProductPrice, details.ProductPrice)
                .Set(x => x.ProductDescription, details.ProductDescription)
                .Set(x => x.ProductName, details.ProductName)
                .Set(x => x.ModifiedAt, DateTime.Now);
            
            return await productCollection.UpdateOneAsync(x => x.Id.Equals(productId) && !x.IsDeleted, update);

        }

        public async Task<UpdateResult> DeleteProductAsync(string productId)
        {
            var update = Builders<Product>.Update
                .Set(x => x.DeletedAt, DateTime.Now)
                .Set(x => x.IsDeleted, true);
           return await productCollection.UpdateOneAsync(x => x.Id.Equals(productId) && !x.IsDeleted, update);

        }
    }
}
