using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "American city", "New York" });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Indian City", "Hyderabad" });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Isaraeilian city", "Jerusellam" });

            migrationBuilder.InsertData(
                table: "pointsOfInterests",
                columns: new[] { "id", "Description", "Name", "cityId" },
                values: new object[] { 1, "Description", "Name", 1 });

            migrationBuilder.InsertData(
                table: "pointsOfInterests",
                columns: new[] { "id", "Description", "Name", "cityId" },
                values: new object[] { 2, "Description2", "Name2", 1 });

            migrationBuilder.InsertData(
                table: "pointsOfInterests",
                columns: new[] { "id", "Description", "Name", "cityId" },
                values: new object[] { 3, "Description", "Name", 2 });

            migrationBuilder.InsertData(
                table: "pointsOfInterests",
                columns: new[] { "id", "Description", "Name", "cityId" },
                values: new object[] { 4, "Description2", "Name2", 2 });

            migrationBuilder.InsertData(
                table: "pointsOfInterests",
                columns: new[] { "id", "Description", "Name", "cityId" },
                values: new object[] { 5, "Description", "Name", 3 });

            migrationBuilder.InsertData(
                table: "pointsOfInterests",
                columns: new[] { "id", "Description", "Name", "cityId" },
                values: new object[] { 6, "Description2", "Name2", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pointsOfInterests",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pointsOfInterests",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "pointsOfInterests",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pointsOfInterests",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "pointsOfInterests",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "pointsOfInterests",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "cities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
