using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTrannsferObjects
{
    //IEnumerable<EmployeeForCreationDto> Employees for creating children resources together with a parent 
    public record CompanyForCreationDto : CompanyForManipulationDto;
    

}
