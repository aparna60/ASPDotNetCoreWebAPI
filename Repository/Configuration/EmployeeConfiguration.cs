using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData
                (
                new Employee
                {
                    Id = new Guid("9208e2f4-0040-450f-ab9f-672e570d31bf"),
                    Name="Deepika Padukone",
                    Age=35,
                    Position="Director",
                    CompanyId=new Guid("60f3fb1e-20c7-443a-9e3f-c9d4606a1af2")
                },
                 new Employee
                 {
                     Id = new Guid("61cf9b60-b44f-4fdb-a3e8-92aedee59bd5"),
                     Name = "Kriti Sanon",
                     Age = 32,
                     Position = "CEO",
                     CompanyId = new Guid("559fbd83-c758-4d5d-b62a-43f7ee6c66ed")
                 },
                  new Employee
                  {
                      Id = new Guid("e38b7b92-317e-4388-8188-0640e46cabfa"),
                      Name = "Aditya Kapoor",
                      Age = 37,
                      Position = "Executive",
                      CompanyId = new Guid("60f3fb1e-20c7-443a-9e3f-c9d4606a1af2")
                  },
                   new Employee
                   {
                       Id = new Guid("61d4de3d-b743-471d-844a-501c02e88bad"),
                       Name = "Rani Mukherjee",
                       Age = 42,
                       Position = "Founder",
                       CompanyId = new Guid("559fbd83-c758-4d5d-b62a-43f7ee6c66ed")
                   }
                );
        }
    }
}
