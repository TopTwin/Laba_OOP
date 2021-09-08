using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Laba4._5_OOP.Storage.Migrations
{
    public partial class InicialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAuthor",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAuthor", x => x.gId);
                });

            migrationBuilder.CreateTable(
                name: "tblLibrary",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLibrary", x => x.gId);
                });

            migrationBuilder.CreateTable(
                name: "tblReader",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(nullable: false),
                    szSName = table.Column<string>(nullable: false),
                    tmRegistration = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblReader", x => x.gId);
                });

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(nullable: false),
                    intQuantity = table.Column<int>(nullable: false),
                    gLibrary = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.gId);
                    table.ForeignKey(
                        name: "FK_tblCategory_tblLibrary_gLibrary",
                        column: x => x.gLibrary,
                        principalTable: "tblLibrary",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblWorker",
                columns: table => new
                {
                    gWorkerId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(nullable: false),
                    intSalary = table.Column<int>(nullable: false),
                    LibraryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWorker", x => x.gWorkerId);
                    table.ForeignKey(
                        name: "FK_tblWorker_tblLibrary_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "tblLibrary",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBook",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    szName = table.Column<string>(nullable: false),
                    szAuthor = table.Column<string>(nullable: false),
                    szCategory = table.Column<string>(nullable: false),
                    gAuthor = table.Column<Guid>(nullable: true),
                    gCategory = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBook", x => x.gId);
                    table.ForeignKey(
                        name: "FK_tblBook_tblAuthor_gAuthor",
                        column: x => x.gAuthor,
                        principalTable: "tblAuthor",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblBook_tblCategory_gCategory",
                        column: x => x.gCategory,
                        principalTable: "tblCategory",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCopyOfBook",
                columns: table => new
                {
                    gId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false),
                    ReaderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCopyOfBook", x => x.gId);
                    table.ForeignKey(
                        name: "FK_tblCopyOfBook_tblBook_BookId",
                        column: x => x.BookId,
                        principalTable: "tblBook",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCopyOfBook_tblReader_ReaderId",
                        column: x => x.ReaderId,
                        principalTable: "tblReader",
                        principalColumn: "gId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblBook_gAuthor",
                table: "tblBook",
                column: "gAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_tblBook_gCategory",
                table: "tblBook",
                column: "gCategory");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_gLibrary",
                table: "tblCategory",
                column: "gLibrary");

            migrationBuilder.CreateIndex(
                name: "IX_tblCopyOfBook_BookId",
                table: "tblCopyOfBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCopyOfBook_ReaderId",
                table: "tblCopyOfBook",
                column: "ReaderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblWorker_LibraryId",
                table: "tblWorker",
                column: "LibraryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCopyOfBook");

            migrationBuilder.DropTable(
                name: "tblWorker");

            migrationBuilder.DropTable(
                name: "tblBook");

            migrationBuilder.DropTable(
                name: "tblReader");

            migrationBuilder.DropTable(
                name: "tblAuthor");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblLibrary");
        }
    }
}
