using Microsoft.EntityFrameworkCore.Migrations;

namespace Laba4._5_OOP.Storage.Migrations
{
    public partial class InicialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "szAuthor",
                table: "tblBook");

            migrationBuilder.DropColumn(
                name: "szCategory",
                table: "tblBook");

            migrationBuilder.AddColumn<string>(
                name: "szPosition",
                table: "tblWorker",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "szPosition",
                table: "tblWorker");

            migrationBuilder.AddColumn<string>(
                name: "szAuthor",
                table: "tblBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "szCategory",
                table: "tblBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
