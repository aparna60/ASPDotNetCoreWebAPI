using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFieldsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                table: "AspNetUsers",
                name: "RefreshToken",
                type: "nvarchar(max)",
               nullable: true );

            migrationBuilder.AddColumn<string>(
                 table: "AspNetUsers",
                 name: "RefreshTokenExpiryTime",
                 type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1,1,1,0,0,0,0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                table: "AspNetUsers",
                name: "RefreshToken");

            migrationBuilder.DropColumn(
               table: "AspNetUsers",
               name: "RefreshTokenExpiryTime");
        }
    }
}
