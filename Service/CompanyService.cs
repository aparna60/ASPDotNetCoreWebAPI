using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTrannsferObjects;
using Entities.Exceptions;
using System.ComponentModel.Design;


namespace Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
        {
                var companies = await _repository.Company.GetAllCompaniesAsync(trackChanges);
                var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
                return companiesDto; 
            
        }

        public async Task<CompanyDto> GetCompanyAsync(Guid companyId, bool trackChanges)
        {

            Company? company = await GetCompanyAndCheckIfExists(companyId, trackChanges);
            var companyDto= _mapper.Map<CompanyDto>(company);
            return companyDto;
        }

        public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
        {
            var companyEnity = _mapper.Map<Company>(company);

            _repository.Company.CreateCompany(companyEnity);
            await _repository.SaveAsync();

            var companyReturn = _mapper.Map<CompanyDto>(companyEnity);
            return companyReturn;

        }

        public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var companyEntities= await _repository.Company.GetByIdsAsync(ids, trackChanges);

            if(ids.Count() != companyEntities.Count())
                throw new CollectionByIdsBadRequestException();
            
            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            return companiesToReturn;
        }

        public async Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();
            var companyEntities= _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repository.Company.CreateCompany(company);
            }
           await _repository.SaveAsync();

            var CompanyCollectionToReturn= _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids= string.Join(",", CompanyCollectionToReturn.Select(c => c.Id));

            return (companies: CompanyCollectionToReturn, ids: ids);

        }

        public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
        {
            Company? company = await GetCompanyAndCheckIfExists(companyId, trackChanges);
            _repository.Company.DeleteCompany(company);
           await  _repository.SaveAsync();

        }

        public async Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges)
        {
            Company? compnay = await GetCompanyAndCheckIfExists(companyId, trackChanges);
            _mapper.Map(companyForUpdate, compnay);
            await _repository.SaveAsync();

        }

        private async Task<Company?> GetCompanyAndCheckIfExists(Guid companyId, bool trackChanges)
        {
            var compnay = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (compnay is null)
                throw new CompanyNotFoundException(companyId);
            return compnay;
        }
    }
}
