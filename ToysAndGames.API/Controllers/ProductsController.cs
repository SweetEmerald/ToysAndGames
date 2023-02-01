using Microsoft.AspNetCore.Mvc;
using ToysAndGames.DTO.ModelsDTO;
using ToysAndGames.Services.Interfaces;

namespace ToysAndGames.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductsController.ProductService: Get All Failed");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductAsync(int productId)
        {
            try
            {
                var product = await _productService.GetProductAsync(productId);
                if (product == null)
                    return NotFound($"Product with id {productId} not found");
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductController.ProductService: Get Product Failed");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDTO addProductDTO)
        {
            //TODO: Validations
            try
            {
                var product = await _productService.AddProductAsync(addProductDTO);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductController.ProductService: Add Product Failed");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdProductDTO updProductDTO)
        {
            //TODO: Validations
            try
            {
                var product = await _productService.UpdateProductASync(updProductDTO);
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductController.ProductService: Update Product Failed");
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var response = await _productService.DeleteProductAsync(productId);
                if (response)
                    return NoContent();
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ProductController.ProductService: Delete Product Failed");
                return BadRequest(ex.Message);
            }
        }
    }
}
