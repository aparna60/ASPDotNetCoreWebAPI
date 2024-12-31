using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTrannsferObjects
{
    public abstract record EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employeee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 characters.")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Age field is required.")]

        [Range(18, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 18")]
        public int Age { get; init; }

        [Required(ErrorMessage = "Position field is a require field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the posotion is 20 characters.")]
        public string? Position { get; init; }
    }
}
