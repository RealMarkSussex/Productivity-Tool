using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class RemovedCategoryDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpendItems_SpendCategory_SpendCategoryId",
                table: "SpendItems");

            migrationBuilder.DropTable(
                name: "SpendCategory");

            migrationBuilder.DropIndex(
                name: "IX_SpendItems_SpendCategoryId",
                table: "SpendItems");

            migrationBuilder.DropColumn(
                name: "SpendCategoryId",
                table: "SpendItems");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "SpendItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "SpendItems");

            migrationBuilder.AddColumn<Guid>(
                name: "SpendCategoryId",
                table: "SpendItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SpendCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpendCategory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpendItems_SpendCategoryId",
                table: "SpendItems",
                column: "SpendCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpendItems_SpendCategory_SpendCategoryId",
                table: "SpendItems",
                column: "SpendCategoryId",
                principalTable: "SpendCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
