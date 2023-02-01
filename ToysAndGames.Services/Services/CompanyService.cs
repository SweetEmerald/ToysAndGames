using AutoMapper;
using ToysAndGames.Data;
using ToysAndGames.DTO.ModelsDTO;
using ToysAndGames.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToysAndGames.Data.Models;

namespace ToysAndGames.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ToysAndGamesDbContext _context;
        private readonly IMapper _mapper;

        public CompanyService(ToysAndGamesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CompanyDTO>> GetAllCompaniesAsync()
        {
            try
            {
                var companyList = await _context.Companies.AsNoTracking().ToListAsync();
                List<CompanyDTO> result = _mapper.Map<List<CompanyDTO>>(companyList);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompanyDTO> GetCompanyAsync(int companyId)
        {
            try
            {
                var company = await _context.Companies.FirstOrDefaultAsync(p => p.Id == companyId);

                CompanyDTO result = _mapper.Map<CompanyDTO>(company);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompanyDTO> AddCompanyAsync(AddCompanyDTO addCompanyDTO)
        {
            try
            {
                Company company = _mapper.Map<Company>(addCompanyDTO);
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();

                var companyDTO = await GetCompanyAsync(company.Id);

                return companyDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<CompanyDTO> UpdateCompanyASync(CompanyDTO request)
        {
            try
            {
                var company = await _context.Companies.FindAsync(request.Id);

                if (company == null)
                    throw new Exception("Company not found");
                company.Name = request.Name;

                await _context.SaveChangesAsync();

                var companyDTO = await GetCompanyAsync(company.Id);

                return companyDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteCompanyAsync(int companyId)
        {
            try
            {
                var company = await _context.Companies.FindAsync(companyId);
                if (company == null)
                    return false;

                _context.Companies.Remove(company);
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
