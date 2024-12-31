using Contracts;
using Entities.LinkModels;
using Entities.Models;
using Microsoft.Net.Http.Headers;
using Shared.DataTrannsferObjects;

namespace CompanyEmployees.Utility
{
    public class EmployeeLinks : IEmployeeLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<EmployeeDto> _dataShaper;

        public EmployeeLinks(LinkGenerator linkGenerator, IDataShaper<EmployeeDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;   
                
        }

        public LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeeDto, string fields, Guid companyId, HttpContext httpContext)
        {
            var shapedEmployees = ShapedData(employeeDto, fields);

            if(ShouldGenerateLinks(httpContext))
                return ReturnLinkedEmployees(employeeDto, fields, companyId, httpContext, shapedEmployees);

            return ReturnShapedEmployees(shapedEmployees);
        }
        
        private LinkResponse ReturnShapedEmployees(List<Entity> shapedEmployees)=> new LinkResponse { ShapedEntities = shapedEmployees };
        private LinkResponse ReturnLinkedEmployees(IEnumerable<EmployeeDto> employeeDto, string fields, Guid companyId, HttpContext httpContext, List<Entity> shapedEmployees)
        {
            var employeeDtoList = employeeDto.ToList();

            for(var index=0; index< employeeDtoList.Count(); index++)
            {
                var employeeLinks = CreateLinksForEmployee(httpContext, companyId, employeeDtoList[index].Id, fields);
                shapedEmployees[index].Add("Links", employeeLinks);
            }

            var employeeCollection = new LinkCollectionWrapper<Entity>(shapedEmployees);
            var linkedEmployees = CreateLinksForEmployees(httpContext, employeeCollection);

            return new LinkResponse { HasLinks = true , LinkEntities = linkedEmployees };

        }

        private LinkCollectionWrapper<Entity> CreateLinksForEmployees(HttpContext httpContext, LinkCollectionWrapper<Entity> employeesWrapper)
        {
            employeesWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext,
                "GetEmployeesForCompany", values: new { }),
                "self",
                "GET"));

            return employeesWrapper;
        }

        private List<Link> CreateLinksForEmployee(HttpContext httpContext, Guid companyId, Guid id, string fields="")
        {
           var links =new List<Link>
            {
                new Link(_linkGenerator.GetUriByAction(httpContext, "GetEmployeeForCompany",
             values: new { companyId, id, fields }),
                    "self",
                    "GET"),

                    new Link(_linkGenerator.GetUriByAction(httpContext, "DeleteEmployeeForCompany",
             values: new { companyId, id }),
                    "delete_employee",
                    "DELETE"),

                    new Link(_linkGenerator.GetUriByAction(httpContext, "UpdateEmployeeForCompany",
             values: new { companyId, id}),
                    "update_employee",
                    "PUT"),


                    new Link(_linkGenerator.GetUriByAction(httpContext, "PartiallyUpdateEmployeeForCompany",
             values: new { companyId, id}),
                    "partially_update_employee",
                    "PATCH")

            };

            return links;
        }

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
           
            //  var mediaType = (MediaTypeHeaderValue)httpContext.Items["AcceptHeaderMediaType"];

            var mediaType = new MediaTypeHeaderValue("application/vnd.aparna.hateoas+json");
            httpContext.Items["AcceptHeaderMediaType"] = mediaType;


            return mediaType.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private List<Entity> ShapedData(IEnumerable<EmployeeDto> employeeDto, string fields) => 
               
               _dataShaper.ShapeData(employeeDto, fields)
               .Select(e => e.Entity)
               .ToList();

       
    }
}
