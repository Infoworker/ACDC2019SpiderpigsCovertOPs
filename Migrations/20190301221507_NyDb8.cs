using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACDC2019SpiderpigsCovertOPs.Migrations
{
    public partial class NyDb8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Age",
                table: "Persons",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FavoriteDrink",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FavoriteFood",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quote",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FavoriteDrink",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FavoriteFood",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Quote",
                table: "Persons");
        }
    }
}
