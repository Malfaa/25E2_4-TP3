using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityBreaks.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Cities_CityId",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "PricePerNight",
                table: "Properties",
                newName: "price_per_night");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Properties",
                newName: "property_name");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Properties",
                newName: "city_id_fk");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Properties",
                newName: "property_id");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_CityId",
                table: "Properties",
                newName: "IX_Properties_city_id_fk");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "country_name");

            migrationBuilder.RenameColumn(
                name: "CountryCode",
                table: "Countries",
                newName: "country_code");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Countries",
                newName: "country_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "city_name");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Cities",
                newName: "country_id_fk");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cities",
                newName: "city_id");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                newName: "IX_Cities_country_id_fk");

            migrationBuilder.AlterColumn<decimal>(
                name: "price_per_night",
                table: "Properties",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "country_id", "country_code", "country_name" },
                values: new object[] { 1, "BRA", "Brasil" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "city_id", "country_id_fk", "city_name" },
                values: new object[,]
                {
                    { 1, 1, "Rio De Janeiro" },
                    { 2, 1, "São Paulo" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "property_id", "city_id_fk", "property_name", "price_per_night" },
                values: new object[,]
                {
                    { 1, 1, "Apartamento Copacabana Vista Mar", 750.00m },
                    { 2, 1, "Casa Charmosa em Santa Teresa", 500.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_country_code",
                table: "Countries",
                column: "country_code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_country_id_fk",
                table: "Cities",
                column: "country_id_fk",
                principalTable: "Countries",
                principalColumn: "country_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Cities_city_id_fk",
                table: "Properties",
                column: "city_id_fk",
                principalTable: "Cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_country_id_fk",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Cities_city_id_fk",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Countries_country_code",
                table: "Countries");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "property_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "property_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "city_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "country_id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "property_name",
                table: "Properties",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "price_per_night",
                table: "Properties",
                newName: "PricePerNight");

            migrationBuilder.RenameColumn(
                name: "city_id_fk",
                table: "Properties",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "property_id",
                table: "Properties",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_city_id_fk",
                table: "Properties",
                newName: "IX_Properties_CityId");

            migrationBuilder.RenameColumn(
                name: "country_name",
                table: "Countries",
                newName: "CountryName");

            migrationBuilder.RenameColumn(
                name: "country_code",
                table: "Countries",
                newName: "CountryCode");

            migrationBuilder.RenameColumn(
                name: "country_id",
                table: "Countries",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "country_id_fk",
                table: "Cities",
                newName: "CountryId");

            migrationBuilder.RenameColumn(
                name: "city_name",
                table: "Cities",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "city_id",
                table: "Cities",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_country_id_fk",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.AlterColumn<decimal>(
                name: "PricePerNight",
                table: "Properties",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Cities_CityId",
                table: "Properties",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
