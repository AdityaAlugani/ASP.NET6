using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    public partial class foriegnkeyadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pointsOfInterests_cities_cityId",
                table: "pointsOfInterests");

            migrationBuilder.DropIndex(
                name: "IX_pointsOfInterests_cityId",
                table: "pointsOfInterests");

            migrationBuilder.DropColumn(
                name: "cityId",
                table: "pointsOfInterests");

            migrationBuilder.AddColumn<int>(
                name: "foriegnkey",
                table: "pointsOfInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pointsOfInterests_foriegnkey",
                table: "pointsOfInterests",
                column: "foriegnkey");

            migrationBuilder.AddForeignKey(
                name: "FK_pointsOfInterests_cities_foriegnkey",
                table: "pointsOfInterests",
                column: "foriegnkey",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pointsOfInterests_cities_foriegnkey",
                table: "pointsOfInterests");

            migrationBuilder.DropIndex(
                name: "IX_pointsOfInterests_foriegnkey",
                table: "pointsOfInterests");

            migrationBuilder.DropColumn(
                name: "foriegnkey",
                table: "pointsOfInterests");

            migrationBuilder.AddColumn<int>(
                name: "cityId",
                table: "pointsOfInterests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pointsOfInterests_cityId",
                table: "pointsOfInterests",
                column: "cityId");

            migrationBuilder.AddForeignKey(
                name: "FK_pointsOfInterests_cities_cityId",
                table: "pointsOfInterests",
                column: "cityId",
                principalTable: "cities",
                principalColumn: "Id");
        }
    }
}
