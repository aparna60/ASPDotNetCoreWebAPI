using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(Guid companyId) :
            base($"Company with the id: {companyId} doesn't exists in the database") { }
       
    }
}
