using Microsoft.EntityFrameworkCore.Migrations;

namespace Laba4._5_OOP.Storage.Migrations
{
    public partial class InicialCreate6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBook_tblAuthor_gAuthor",
                table: "tblBook");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBook_tblCategory_gCategory",
                table: "tblBook");

            migrationBuilder.RenameColumn(
                name: "gCategory",
                table: "tblBook",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "gAuthor",
                table: "tblBook",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_tblBook_gCategory",
                table: "tblBook",
                newName: "IX_tblBook_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_tblBook_gAuthor",
                table: "tblBook",
                newName: "IX_tblBook_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBook_tblAuthor_AuthorId",
                table: "tblBook",
                column: "AuthorId",
                principalTable: "tblAuthor",
                principalColumn: "gId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblBook_tblCategory_CategoryId",
                table: "tblBook",
                column: "CategoryId",
                principalTable: "tblCategory",
                principalColumn: "gId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBook_tblAuthor_AuthorId",
                table: "tblBook");

            migrationBuilder.DropForeignKey(
                name: "FK_tblBook_tblCategory_CategoryId",
                table: "tblBook");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "tblBook",
                newName: "gCategory");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "tblBook",
                newName: "gAuthor");

            migrationBuilder.RenameIndex(
                name: "IX_tblBook_CategoryId",
                table: "tblBook",
                newName: "IX_tblBook_gCategory");

            migrationBuilder.RenameIndex(
                name: "IX_tblBook_AuthorId",
                table: "tblBook",
                newName: "IX_tblBook_gAuthor");

            migrationBuilder.AddForeignKey(
                name: "FK_tblBook_tblAuthor_gAuthor",
                table: "tblBook",
                column: "gAuthor",
                principalTable: "tblAuthor",
                principalColumn: "gId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblBook_tblCategory_gCategory",
                table: "tblBook",
                column: "gCategory",
                principalTable: "tblCategory",
                principalColumn: "gId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
