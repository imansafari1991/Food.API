using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Food.API.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SliderAttributes_Products_ProductId",
                table: "SliderAttributes");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "SliderAttributes",
                newName: "SliderId");

            migrationBuilder.RenameIndex(
                name: "IX_SliderAttributes_ProductId",
                table: "SliderAttributes",
                newName: "IX_SliderAttributes_SliderId");

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SliderAttributes_Slider_SliderId",
                table: "SliderAttributes",
                column: "SliderId",
                principalTable: "Slider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SliderAttributes_Slider_SliderId",
                table: "SliderAttributes");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.RenameColumn(
                name: "SliderId",
                table: "SliderAttributes",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SliderAttributes_SliderId",
                table: "SliderAttributes",
                newName: "IX_SliderAttributes_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SliderAttributes_Products_ProductId",
                table: "SliderAttributes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
