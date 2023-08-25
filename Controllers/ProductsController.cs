using Microsoft.AspNetCore.Mvc;
using ProductsWithMongo.Models.RequestViewModels;
using ProductsWithMongo.Models.ResponseViewModels;
using ProductsWithMongo.Services.Interfaces;

namespace ProductsWithMongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IServiceProvider serviceProvider)
        {
            productService = serviceProvider.GetRequiredService<IProductService>();
        }

        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var result = await productService.ProductListAsync();

                var response = new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "success",
                    Body = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                };
                return Ok(response);
            }
        }

        [HttpGet("get-product/{productId}")]
        public async Task<IActionResult> GetProductById(string productId)
        {
            try
            {
                var result = await productService.GetProductDetailByIdAsync(productId);

                var response = new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "success",
                    Body = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                };
                return Ok(response);
            }
        }

        [HttpPost("insert-product")]
        public async Task<IActionResult> InsertProduct(ProductRequestViewModel productDetails)
        {
            
            try
            {
                var result = await productService.InsertProductAsync(productDetails);


                var response = new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "success",
                    Body = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                };
                return Ok(response);
            }
        }

        [HttpPut("update-product/{productId}")]
        public async Task<IActionResult> UpdateProduct(string productId, UpdateRequestViewModel productDetails)
        {
            try
            {
                var result = await productService.UpdateProductAsync(productId,productDetails);


                var response = new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "success",
                    Body = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                };
                return Ok(response);
            }
        }

        [HttpDelete("delete-product/{productId}")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {

            try
            {
                var result = await productService.DeleteProductAsync(productId);


                var response = new ApiResponseViewModel
                {
                    Code = 200,
                    Message = "success",
                    Body = result
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponseViewModel
                {
                    Code = 500,
                    Message = ex.Message,
                    Body = null
                };
                return Ok(response);
            }
        }
    }
}