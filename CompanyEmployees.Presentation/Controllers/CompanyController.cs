﻿

using CompanyEmployees.Presentation.ActionFilters;
using CompanyEmployees.Presentation.ModelBinders;
using Marvin.Cache.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service.Contracts;
using Shared.DataTrannsferObjects;


namespace CompanyEmployees.Presentation.Controllers
{
    //[ApiVersion("1.0")]
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CompanyController(IServiceManager service)=>
            _service = service;


        [HttpGet(Name ="GetCompanies")]
        [Authorize(Roles ="Manager")]
        [ResponseCache(CacheProfileName = "120SecondsDuration")]
        public async Task<IActionResult> GetCompanies()
        {
                var companies = await _service.CompanyService.GetAllCompaniesAsync(trackChanges: false);
                return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
       //[ResponseCache(Duration =60)]
        [HttpCacheExpiration(CacheLocation= CacheLocation.Public ,MaxAge =60)]
        [HttpCacheValidation(MustRevalidate = false)]
     
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _service.CompanyService.GetCompanyAsync(id, trackChanges: false);
            return Ok(company);
        }

        [HttpPost(Name = "CreateCompany")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
        {
            //This validation code is replaced by Validation Filter Attribute action Filter
            //if (company is null)
            //    return BadRequest("CompanyCreationDto object is null");

            //if(!ModelState.IsValid)
            //    return UnprocessableEntity(ModelState);

            var createdCompany = await _service.CompanyService.CreateCompanyAsync(company);
            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }

        [HttpGet("collection/({ids})", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType= typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var companies = await _service.CompanyService.GetByIdsAsync(ids, trackChanges: false);
            return Ok(companies);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companyCollection)
        {
            var result= await _service.CompanyService.CreateCompanyCollectionAsync(companyCollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids } , result.companies); 
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            await _service.CompanyService.DeleteCompanyAsync(id, trackChanges : false);
            return NoContent();

        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            //This validation code is replaced by Validation Filter Attribute action Filter
            //if (company == null)
            //    return BadRequest("CompanyForUpdateDto object is null");

            //if (!ModelState.IsValid)
            //     return UnprocessableEntity(ModelState);

            await _service.CompanyService.UpdateCompanyAsync(id,company,trackChanges: true);
            return NoContent();
        }

        //OPTIONS 

        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");
            return Ok();
        }




    }


}
