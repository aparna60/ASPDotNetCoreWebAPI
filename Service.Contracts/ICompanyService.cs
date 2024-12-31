using Shared.DataTrannsferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);
        Task<CompanyDto> GetCompanyAsync(Guid Companyid, bool trackChanges);

        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);

        //For the company collection method post method return path
        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        //For the company collection post method
        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection);

        //Deleting a Parent Resource with its Children

        Task DeleteCompanyAsync(Guid Companyid, bool trackChanges);

        //Inserting resources(Epmployees) while updating One(Company)

        Task UpdateCompanyAsync(Guid companyId, CompanyForUpdateDto companyForUpdate, bool trackChanges);
    }
}
