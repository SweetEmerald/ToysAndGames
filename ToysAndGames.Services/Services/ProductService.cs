using AutoMapper;
using ToysAndGames.Data;
using ToysAndGames.DTO.ModelsDTO;
using ToysAndGames.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToysAndGames.Data.Models;

namespace ToysAndGames.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly ToysAndGamesDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorage? _fileStorage;

        public ProductService(ToysAndGamesDbContext context, IMapper mapper, IFileStorage? fileStorage)
        {
            _context = context;
            _mapper = mapper;
            _fileStorage = fileStorage;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            try
            {
                var productList = await _context.Products.AsNoTracking().Include(x=>x.Companies).ToListAsync();
                List<ProductDTO> result = _mapper.Map<List<ProductDTO>>(productList);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductDTO> GetProductAsync(int productId)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

                ProductDTO result = _mapper.Map<ProductDTO>(product);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductDTO> AddProductAsync(AddProductDTO addProductDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(addProductDTO);

                if (addProductDTO.Image != null && _fileStorage!=null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await addProductDTO.Image.CopyToAsync(memoryStream);
                        var content = memoryStream.ToArray();
                        var extension = Path.GetExtension(addProductDTO.Image.FileName);
                        product.Image = await _fileStorage.SaveFile(content, extension, "products", addProductDTO.Image.ContentType);
                    }
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                var productDTO = await GetProductAsync(product.Id);

                return productDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ProductDTO> UpdateProductASync(UpdProductDTO request)
        {
            try
            {
                var product = await _context.Products.FindAsync(request.Id);

                if (product == null)
                    throw new Exception("Product not found");
                product.Name = request.Name;
                product.Price = request.Price;
                product.Description = request.Description;
                product.AgeRestriction = request.AgeRestriction;
                product.CompanyId = request.CompanyId;

                if (request.Image != null && _fileStorage!=null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.Image.CopyToAsync(memoryStream);
                        var content = memoryStream.ToArray();
                        var extension = Path.GetExtension(request.Image.FileName);
                        product.Image = await _fileStorage.SaveFile(content, extension, "products", request.Image.ContentType);
                    }
                }

                await _context.SaveChangesAsync();

                var productDTO = await GetProductAsync(product.Id);

                return productDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
