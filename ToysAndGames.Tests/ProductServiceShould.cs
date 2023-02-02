using ToysAndGames.DTO.ModelsDTO;
using ToysAndGames.Services.Services;
using ToysAndGames.Tests.Fixtures;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace ToysAndGames.Tests
{
    [Collection("Database collection")]
    public class ProductServiceShould
    {
        private readonly ToysAndGamesDbContextFixture _dbFixture;
        private readonly MapperFixture _mapperFixture;

        public ProductServiceShould(ToysAndGamesDbContextFixture dbFixture, MapperFixture mapperFixture)
        {
            _dbFixture = dbFixture;
            _mapperFixture = mapperFixture;
        }

        [Fact]
        public async void ReturnAllProducts()
        {
            //Arrange
            var sut = new ProductService(_dbFixture.Context, _mapperFixture.Mapper, null);

            //Act
            var products = await sut.GetAllProductsAsync();

            //Assert
            Assert.NotEmpty(products);
        }

        [Theory]
        [InlineData(1)]
        public async void ReturnProductOrThrow(int productId)
        {
            //Arrange
            var sut = new ProductService(_dbFixture.Context, _mapperFixture.Mapper, null);

            //Act
            var product = await sut.GetProductAsync(productId);

            //Assert
            Assert.IsType<ProductDTO>(product);
        }

        [Theory]
        [InlineData("LEGO 10968 Duplo Visita Médica", "Set de 34 piezas. Figuras de una doctora, un papá y una niña, un osito de peluche, un medidor de altura, un lavabo, un sofá, un maletín que se abre y sillas.", 3, 3, 500)]
        public async void ReturnAddProduct(string name, string description, int companyId, int ageRestriction, decimal price)
        {
            //Arrange
            var product = new AddProductDTO() { Name = name, Description = description, CompanyId = companyId, AgeRestriction = ageRestriction, Price = price, Image = null };
            var sut = new ProductService(_dbFixture.Context, _mapperFixture.Mapper, null);

            //Act
            var response = await sut.AddProductAsync(product);

            //Assert
            Assert.IsType<ProductDTO>(response);
        }

        [Theory]
        [InlineData(1, "LEGO Duplo Visita Médica", "Set de 34 piezas. Figuras de una doctora, un papá y una niña, un osito de peluche, un medidor de altura, un lavabo, un sofá, un maletín que se abre y sillas.", 3, 3, 400)]
        public async void ReturnUpdateProduct(int id, string name, string description, int companyId, int ageRestriction, decimal price)
        {
            var sut = new ProductService(_dbFixture.Context, _mapperFixture.Mapper, null);

            var product = new UpdProductDTO() { Id = id, Name = name, Description = description, CompanyId = companyId, AgeRestriction = ageRestriction, Price = price, Image = null };
            var response = await sut.UpdateProductASync(product);

            Assert.Equal(product.Price, response.Price);
            Assert.Equal(product.Name, response.Name);
        }

        [Theory]
        [InlineData(1, true)]
        public async void DeleteAValidProduct(int productId, bool succeeds)
        {
            var sut = new ProductService(_dbFixture.Context, _mapperFixture.Mapper, null);

            var deleteSucceded = await sut.DeleteProductAsync(productId);

            Assert.Equal(succeeds, deleteSucceded);
        }
    }
}
