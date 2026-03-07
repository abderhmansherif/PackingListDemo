using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackingList.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Read : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Packit");

            migrationBuilder.CreateTable(
                name: "PackingLists",
                schema: "Packit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackingListItems",
                schema: "Packit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsPacked = table.Column<bool>(type: "bit", nullable: false),
                    PackingListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackingListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackingListItems_PackingLists_PackingListId",
                        column: x => x.PackingListId,
                        principalSchema: "Packit",
                        principalTable: "PackingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackingListItems_PackingListId",
                schema: "Packit",
                table: "PackingListItems",
                column: "PackingListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackingListItems",
                schema: "Packit");

            migrationBuilder.DropTable(
                name: "PackingLists",
                schema: "Packit");
        }
    }
}
