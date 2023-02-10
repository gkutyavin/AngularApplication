using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Country 1" },
                    { 2, "Country 2" },
                    { 3, "Country 3" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "ID", "CountryID", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Province 1.1" },
                    { 2, 2, "Province 2.1" },
                    { 3, 2, "Province 2.2" },
                    { 4, 2, "Province 2.3" },
                    { 5, 3, "Province 3.1" },
                    { 6, 3, "Province 3.2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
