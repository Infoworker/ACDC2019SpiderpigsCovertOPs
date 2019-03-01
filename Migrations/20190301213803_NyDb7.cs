using Microsoft.EntityFrameworkCore.Migrations;

namespace ACDC2019SpiderpigsCovertOPs.Migrations
{
    public partial class NyDb7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Persons_PersonId",
                table: "Locations");

            migrationBuilder.AlterColumn<long>(
                name: "PersonId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Persons_PersonId",
                table: "Locations",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Persons_PersonId",
                table: "Locations");

            migrationBuilder.AlterColumn<long>(
                name: "PersonId",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Persons_PersonId",
                table: "Locations",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
