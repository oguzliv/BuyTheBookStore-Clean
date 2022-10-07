using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyTheBookStore.DataAccess.Migrations
{
    public partial class orderrelationnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    AuthorName = table.Column<string>(type: "text", nullable: false),
                    GenreText = table.Column<string>(type: "text", nullable: false),
                    Genre = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    SellCount = table.Column<int>(type: "integer", nullable: false),
                    NSPF = table.Column<double>(type: "double precision", nullable: false, computedColumnSql: "\"SellCount\"/\"Price\"", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    RoleText = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderedBooks = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "Genre", "GenreText", "Name", "Price", "SellCount" },
                values: new object[,]
                {
                    { new Guid("1085e04b-86a7-461a-952f-8715cb1ccff8"), "author1", 0, "ACTION", "book1", 15.0, 20 },
                    { new Guid("27058523-d841-4bf4-8ab3-2c7b232af066"), "author2", 0, "ACTION", "book2", 30.0, 40 },
                    { new Guid("37a681ae-1178-4868-9dce-04e59e06605c"), "author3", 0, "ACTION", "book3", 25.0, 40 },
                    { new Guid("da5cf20a-6ffb-42fe-8d7f-756868000585"), "author6", 1, "ROMANCE", "book6", 10.0, 40 },
                    { new Guid("daba9607-84df-40a3-b709-b74ce16108d1"), "author5", 1, "ROMANCE", "book5", 20.0, 20 },
                    { new Guid("ed6aee94-fc2d-43e8-b7f2-335eab16965e"), "author4", 0, "ACTION", "book4", 65.0, 100 },
                    { new Guid("ee8e99f9-f659-41d3-9acf-d7fc9904330e"), "author6", 0, "ACTION", "book7", 35.0, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
