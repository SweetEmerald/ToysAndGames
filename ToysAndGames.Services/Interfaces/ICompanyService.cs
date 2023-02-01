using ToysAndGames.DTO.ModelsDTO;
namespace ToysAndGames.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<List<CompanyDTO>> GetAllCompaniesAsync();
        Task<CompanyDTO> GetCompanyAsync(int productId);
        Task<CompanyDTO> AddCompanyAsync(AddCompanyDTO request);
        Task<CompanyDTO> UpdateCompanyASync(CompanyDTO request);
        Task<bool> DeleteCompanyAsync(int companyId);
    }
}
