using Microsoft.AspNetCore.Mvc;
using ToysAndGames.DTO.ModelsDTO;
using ToysAndGames.Services.Interfaces;

namespace ToysAndGames.API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompaniesController> _logger;

        public CompaniesController(ICompanyService companyService, ILogger<CompaniesController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var companies = await _companyService.GetAllCompaniesAsync();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CompaniesController.CompanyService: Get All Failed");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetCompanyAsync(int companyId)
        {
            try
            {
                var company = await _companyService.GetCompanyAsync(companyId);
                if (company == null)
                    return NotFound($"Company with id {companyId} not found");
                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CompaniesController.CompanyService: Get Company Id Failed");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(AddCompanyDTO addCompanyDTO)
        {
            //TODO: Validations
            try
            {
                var company = await _companyService.AddCompanyAsync(addCompanyDTO);
                return Ok(company);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CompaniesController.CompanyService: Add Company Failed");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany(CompanyDTO request)
        {
            //TODO: Validations
            try
            {
                var response = await _companyService.UpdateCompanyASync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CompaniesController.CompanyService: Update Company Failed");
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{companyId}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            try
            {
                var response = await _companyService.DeleteCompanyAsync(companyId);
                if (response)
                    return NoContent();
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CompaniesController.CompanyService: Delete Company Failed");
                return BadRequest(ex.Message);
            }
        }
    }
}
