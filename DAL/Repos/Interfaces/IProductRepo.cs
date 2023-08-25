using MongoDB.Driver;
using ProductsWithMongo.DAL.Entities;
using ProductsWithMongo.Models.RequestViewModels;

namespace ProductsWithMongo.DAL.Repos.Interfaces
{
    public interface IProductRepo
    {
        public Task<List<Product>> ProductListAsync();
        public Task<Product> GetProductDetailByIdAsync(string productId);
        public Task<Product?> AddProductAsync(ProductRequestViewModel productDetails);
        public Task<UpdateResult> UpdateProductAsync(string productId, UpdateRequestViewModel productDetails);
        public Task<UpdateResult> DeleteProductAsync(string productId);
    }
}
