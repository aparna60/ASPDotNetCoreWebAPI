using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTrannsferObjects
{
    public abstract record CompanyForManipulationDto
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(30, ErrorMessage = "Company length for the name is 30 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(600, ErrorMessage = "Company address length for the name is 60 characters.")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "Company country is a required field.")]
        [MaxLength(20, ErrorMessage = "Company country length for the name is 20 characters.")]
        public string? Country { get; init; }

        //[Required(ErrorMessage = "At least one employee is required.")]
        //[MinLength(1, ErrorMessage = "There must be at least one employee.")]
        public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
    }
}
