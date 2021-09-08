using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Laba4._5_OOP.Storage.Migrations
{
    public partial class InicialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "gLibrary",
                table: "tblReader",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_tblReader_gLibrary",
                table: "tblReader",
                column: "gLibrary");

            migrationBuilder.AddForeignKey(
                name: "FK_tblReader_tblLibrary_gLibrary",
                table: "tblReader",
                column: "gLibrary",
                principalTable: "tblLibrary",
                principalColumn: "gId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblReader_tblLibrary_gLibrary",
                table: "tblReader");

            migrationBuilder.DropIndex(
                name: "IX_tblReader_gLibrary",
                table: "tblReader");

            migrationBuilder.DropColumn(
                name: "gLibrary",
                table: "tblReader");
        }
    }
}
