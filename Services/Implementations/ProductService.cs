using MongoDB.Driver;
using ProductsWithMongo.DAL.Entities;
using ProductsWithMongo.DAL.Repos.Interfaces;
using ProductsWithMongo.Models.RequestViewModels;
using ProductsWithMongo.Services.Interfaces;

namespace ProductsWithMongo.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _repository;

        public ProductService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IProductRepo>();
        }

        public async Task<Product?> InsertProductAsync(ProductRequestViewModel productDetails)
        {
            return await _repository.AddProductAsync(productDetails);
        }

        public async Task<UpdateResult> DeleteProductAsync(string productId)
        {
            return await _repository.DeleteProductAsync(productId);
        }

        public async Task<Product> GetProductDetailByIdAsync(string productId)
        {
            return await _repository.GetProductDetailByIdAsync(productId);
        }

        public async Task<List<Product>> ProductListAsync()
        {
            return await _repository.ProductListAsync();
        }

        public async Task<UpdateResult> UpdateProductAsync(string productId, UpdateRequestViewModel productDetails)
        {
            return await _repository.UpdateProductAsync(productId, productDetails);   
        }
    }
}
