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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {

            builder.HasData
                (

                new Company
                {
                    Id= new Guid("60f3fb1e-20c7-443a-9e3f-c9d4606a1af2"),
                    Name= "IT Solution Limited",
                    Address="Bangalore",
                    Country="India"

                },
                new Company
                {
                    Id = new Guid("559fbd83-c758-4d5d-b62a-43f7ee6c66ed"),
                    Name = "Admin Solution Limited",
                    Address = "Kolkata",
                    Country = "India"

                }
                );
        }
    }
}
