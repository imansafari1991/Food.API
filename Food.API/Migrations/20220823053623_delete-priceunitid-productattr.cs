using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food.API.Migrations
{
    public partial class deletepriceunitidproductattr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_PriceUnits_PriceUnitId",
                table: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_PriceUnitId",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "PriceUnitId",
                table: "ProductAttributes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceUnitId",
                table: "ProductAttributes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_PriceUnitId",
                table: "ProductAttributes",
                column: "PriceUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_PriceUnits_PriceUnitId",
                table: "ProductAttributes",
                column: "PriceUnitId",
                principalTable: "PriceUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
