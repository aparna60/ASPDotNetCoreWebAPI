using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66c4291e-adbc-4f61-8e00-abb0ff4c057f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7530047b-9c7d-4730-b675-fc32555c9ca3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00d56f7d-d806-46cb-970e-8a4f94095b6f", null, "Administartor", "ADMINISTRATOR" },
                    { "053b16c8-438c-44ed-b2d9-5730d074e8c6", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00d56f7d-d806-46cb-970e-8a4f94095b6f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "053b16c8-438c-44ed-b2d9-5730d074e8c6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66c4291e-adbc-4f61-8e00-abb0ff4c057f", null, "Administartor", "ADMINISTRATOR" },
                    { "7530047b-9c7d-4730-b675-fc32555c9ca3", null, "Manager", "MANAGER" }
                });
        }
    }
}
