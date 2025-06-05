using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityBreaks.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "property_id", "city_id_fk", "property_name", "price_per_night" },
                values: new object[] { 3, 2, "Loft Moderno na Vila Madalena", 600.00m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "property_id",
                keyValue: 3);
        }
    }
}
