using MongoDB.Driver;
using ProductsWithMongo.DAL.Entities;
using ProductsWithMongo.Models.RequestViewModels;

namespace ProductsWithMongo.Services.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> ProductListAsync();
        public Task<Product> GetProductDetailByIdAsync(string productId);
        public Task<Product?> InsertProductAsync(ProductRequestViewModel productDetails);
        public Task<UpdateResult> UpdateProductAsync(string productId, UpdateRequestViewModel productDetails);
        public Task<UpdateResult> DeleteProductAsync(string productId);
    }
}
