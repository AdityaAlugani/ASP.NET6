using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.API.Migrations
{
    public partial class foriegnkeyremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pointsOfInterests_cities_cityid",
                table: "pointsOfInterests");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "pointsOfInterests",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "cityid",
                table: "pointsOfInterests",
                newName: "cityId");

            migrationBuilder.RenameIndex(
                name: "IX_pointsOfInterests_cityid",
                table: "pointsOfInterests",
                newName: "IX_pointsOfInterests_cityId");

            migrationBuilder.AlterColumn<int>(
                name: "cityId",
                table: "pointsOfInterests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_pointsOfInterests_cities_cityId",
                table: "pointsOfInterests",
                column: "cityId",
                principalTable: "cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pointsOfInterests_cities_cityId",
                table: "pointsOfInterests");

            migrationBuilder.RenameColumn(
                name: "cityId",
                table: "pointsOfInterests",
                newName: "cityid");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "pointsOfInterests",
                newName: "description");

            migrationBuilder.RenameIndex(
                name: "IX_pointsOfInterests_cityId",
                table: "pointsOfInterests",
                newName: "IX_pointsOfInterests_cityid");

            migrationBuilder.AlterColumn<int>(
                name: "cityid",
                table: "pointsOfInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_pointsOfInterests_cities_cityid",
                table: "pointsOfInterests",
                column: "cityid",
                principalTable: "cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
