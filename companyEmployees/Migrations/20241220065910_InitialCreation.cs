using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("559fbd83-c758-4d5d-b62a-43f7ee6c66ed"), "Kolkata", "India", "Admin Solution Limited" },
                    { new Guid("60f3fb1e-20c7-443a-9e3f-c9d4606a1af2"), "Bangalore", "India", "IT Solution Limited" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Age", "CompanyId", "Name", "Position" },
                values: new object[,]
                {
                    { new Guid("61cf9b60-b44f-4fdb-a3e8-92aedee59bd5"), 32, new Guid("559fbd83-c758-4d5d-b62a-43f7ee6c66ed"), "Kriti Sanon", "CEO" },
                    { new Guid("61d4de3d-b743-471d-844a-501c02e88bad"), 42, new Guid("559fbd83-c758-4d5d-b62a-43f7ee6c66ed"), "Rani Mukherjee", "Founder" },
                    { new Guid("9208e2f4-0040-450f-ab9f-672e570d31bf"), 35, new Guid("60f3fb1e-20c7-443a-9e3f-c9d4606a1af2"), "Deepika Padukone", "Director" },
                    { new Guid("e38b7b92-317e-4388-8188-0640e46cabfa"), 37, new Guid("60f3fb1e-20c7-443a-9e3f-c9d4606a1af2"), "Aditya Kapoor", "Executive" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("61cf9b60-b44f-4fdb-a3e8-92aedee59bd5"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("61d4de3d-b743-471d-844a-501c02e88bad"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("9208e2f4-0040-450f-ab9f-672e570d31bf"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: new Guid("e38b7b92-317e-4388-8188-0640e46cabfa"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("559fbd83-c758-4d5d-b62a-43f7ee6c66ed"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: new Guid("60f3fb1e-20c7-443a-9e3f-c9d4606a1af2"));
        }
    }
}
