using Microsoft.EntityFrameworkCore.Migrations;

namespace ACDC2019SpiderpigsCovertOPs.Migrations
{
    public partial class NyDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Temprature",
                table: "Sensordatas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Sensordatas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Sensordatas");

            migrationBuilder.AlterColumn<string>(
                name: "Temprature",
                table: "Sensordatas",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
