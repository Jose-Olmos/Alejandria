using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alejandria.WebAPI.Implementation.Data.Migrations
{
    public partial class _20210301_Alejandriainit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(type: "character varying", nullable: false),
                    surname = table.Column<string>(type: "character varying", nullable: false),
                    email = table.Column<string>(type: "character varying", nullable: false),
                    phone = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    summary = table.Column<string>(type: "character varying", nullable: false),
                    genre = table.Column<string>(type: "character varying", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "author-book",
                columns: table => new
                {
                    author = table.Column<Guid>(nullable: false),
                    book = table.Column<Guid>(nullable: false),
                    publishdate = table.Column<DateTime>(name: "publish-date", type: "date", nullable: false),
                    validitydate = table.Column<DateTime>(name: "validity-date", type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("author_books_pk", x => new { x.author, x.book });
                    table.ForeignKey(
                        name: "author_books_fk_1",
                        column: x => x.author,
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "author_books_fk",
                        column: x => x.book,
                        principalTable: "book",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_author-book_book",
                table: "author-book",
                column: "book");

            migrationBuilder.CreateIndex(
                name: "books_title_idx",
                table: "book",
                column: "title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "author-book");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "book");
        }
    }
}
