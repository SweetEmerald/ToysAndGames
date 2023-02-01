using ToysAndGames.DTO.ModelsDTO;
namespace ToysAndGames.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> GetProductAsync(int productId);
        Task<ProductDTO> AddProductAsync(AddProductDTO request);
        Task<ProductDTO> UpdateProductASync(UpdProductDTO request);
        Task<bool> DeleteProductAsync(int productId);
    }
}
