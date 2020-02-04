using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalSystem.Migrations
{
    public partial class ScaffholdedItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "productCategories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productCategories_ProductModelId",
                table: "productCategories",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_productModels_ProductModelId",
                table: "productCategories",
                column: "ProductModelId",
                principalTable: "productModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_productModels_ProductModelId",
                table: "productCategories");

            migrationBuilder.DropIndex(
                name: "IX_productCategories_ProductModelId",
                table: "productCategories");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "productCategories");
        }
    }
}
