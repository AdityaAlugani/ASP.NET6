using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    public partial class foriegnkeyaddedcityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pointsOfInterests_cities_foriegnkey",
                table: "pointsOfInterests");

            migrationBuilder.RenameColumn(
                name: "foriegnkey",
                table: "pointsOfInterests",
                newName: "cityId");

            migrationBuilder.RenameIndex(
                name: "IX_pointsOfInterests_foriegnkey",
                table: "pointsOfInterests",
                newName: "IX_pointsOfInterests_cityId");

            migrationBuilder.AddForeignKey(
                name: "FK_pointsOfInterests_cities_cityId",
                table: "pointsOfInterests",
                column: "cityId",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pointsOfInterests_cities_cityId",
                table: "pointsOfInterests");

            migrationBuilder.RenameColumn(
                name: "cityId",
                table: "pointsOfInterests",
                newName: "foriegnkey");

            migrationBuilder.RenameIndex(
                name: "IX_pointsOfInterests_cityId",
                table: "pointsOfInterests",
                newName: "IX_pointsOfInterests_foriegnkey");

            migrationBuilder.AddForeignKey(
                name: "FK_pointsOfInterests_cities_foriegnkey",
                table: "pointsOfInterests",
                column: "foriegnkey",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
