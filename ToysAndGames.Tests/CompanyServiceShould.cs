using ToysAndGames.DTO.ModelsDTO;
using ToysAndGames.Services.Services;
using ToysAndGames.Tests.Fixtures;
using Xunit;
using static System.Net.Mime.MediaTypeNames;

namespace ToysAndGames.Tests
{
    [Collection("Database collection")]
    public class CompanyServiceShould
    {
        private readonly ToysAndGamesDbContextFixture _dbFixture;
        private readonly MapperFixture _mapperFixture;

        public CompanyServiceShould(ToysAndGamesDbContextFixture dbFixture, MapperFixture mapperFixture)
        {
            _dbFixture = dbFixture;
            _mapperFixture = mapperFixture;
        }

        [Fact]
        public async void ReturnAllCompanies()
        {
            //Arrange
            var sut = new CompanyService(_dbFixture.Context, _mapperFixture.Mapper);

            //Act
            var companies = await sut.GetAllCompaniesAsync();

            //Assert
            Assert.NotEmpty(companies);
        }

        [Theory]
        [InlineData(1)]
        public async void ReturnCompanyOrThrow(int companyId)
        {
            //Arrange
            var sut = new CompanyService(_dbFixture.Context, _mapperFixture.Mapper);

            //Act
            var company = await sut.GetCompanyAsync(companyId);

            //Assert
            Assert.IsType<CompanyDTO>(company);
        }

        [Theory]
        [InlineData("Fisher-Price")]
        public async void ReturnAddCompany(string name)
        {
            //Arrange
            var company = new AddCompanyDTO() { Name = name };
            var sut = new CompanyService(_dbFixture.Context, _mapperFixture.Mapper);

            //Act
            var response = await sut.AddCompanyAsync(company);

            //Assert
            Assert.IsType<CompanyDTO>(response);
        }

        [Theory]
        [InlineData(1, "Fisher-Price")]
        public async void ReturnUpdateCompany(int id, string name)
        {
            var sut = new CompanyService(_dbFixture.Context, _mapperFixture.Mapper);

            var company = new CompanyDTO() { Id = id, Name = name};
            var response = await sut.UpdateCompanyASync(company);

            Assert.Equal(company.Name, response.Name);
        }

        [Theory]
        [InlineData(1, true)]
        public async void DeleteAValidCompany(int companyId, bool succeeds)
        {
            var sut = new CompanyService(_dbFixture.Context, _mapperFixture.Mapper);

            var deleteSucceded = await sut.DeleteCompanyAsync(companyId);

            Assert.Equal(succeeds, deleteSucceded);
        }
    }
}
