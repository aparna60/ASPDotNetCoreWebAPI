
using Entities.LinkModels;
using Microsoft.AspNetCore.Http;
using Shared.DataTrannsferObjects;

namespace Contracts
{
    public interface IEmployeeLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeeDto, 
            string fields, Guid companyId, HttpContext httpContext);
    }
}
