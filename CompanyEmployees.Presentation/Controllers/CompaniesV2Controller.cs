using Microsoft.AspNetCore.Mvc;
using Service.Contracts;


namespace CompanyEmployees.Presentation.Controllers
{
    //For using Query String & HTT Header versioning
    //[ApiVersion("2.0")]
    [Route("api/companies")]
    [ApiVersion("2.0", Deprecated =true)]
    //For URL versioning
    //[Route("api/{v:apiversion}/companies")]


    [ApiController]
    public class CompaniesV2Controller : ControllerBase
    {
        IServiceManager _service;
        public CompaniesV2Controller(IServiceManager service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);
            //For URL versioning
            //var companiesV2 = companies.Select(x => $"{x.Name} V2");
            //return Ok(companiesV2);
            return Ok(companies);
        }

       
    }
}
