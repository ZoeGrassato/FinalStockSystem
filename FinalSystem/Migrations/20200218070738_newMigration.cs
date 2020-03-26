using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalSystem.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "productModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_productModels_ProductModelId",
                table: "productModels",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_productModels_productModels_ProductModelId",
                table: "productModels",
                column: "ProductModelId",
                principalTable: "productModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productModels_productModels_ProductModelId",
                table: "productModels");

            migrationBuilder.DropIndex(
                name: "IX_productModels_ProductModelId",
                table: "productModels");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "productModels");
        }
    }
}
