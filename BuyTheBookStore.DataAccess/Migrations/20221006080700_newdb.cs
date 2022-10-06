using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuyTheBookStore.DataAccess.Migrations
{
    public partial class newdb : Migration
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
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderedBooks = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
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
                    { new Guid("58c11087-dddd-43b0-9585-5e1e666336f4"), "author5", 1, "ROMANCE", "book5", 20.0, 20 },
                    { new Guid("68f68905-2965-4f8f-9da4-3bf13a40eddb"), "author6", 0, "ACTION", "book7", 35.0, 50 },
                    { new Guid("7b1a4714-bd24-4fff-ad1e-6d8c260e79da"), "author1", 0, "ACTION", "book1", 15.0, 20 },
                    { new Guid("96d593c6-821b-446e-a2b4-be8c4e9fe179"), "author6", 1, "ROMANCE", "book6", 10.0, 40 },
                    { new Guid("9d8028ce-574c-49e6-b572-5794cb157507"), "author2", 0, "ACTION", "book2", 30.0, 40 },
                    { new Guid("aaaaaee4-7a3e-4bab-811b-8942554c78c6"), "author4", 0, "ACTION", "book4", 65.0, 100 },
                    { new Guid("c598db90-dcb7-4d71-b925-9688c0247b36"), "author3", 0, "ACTION", "book3", 25.0, 40 }
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
