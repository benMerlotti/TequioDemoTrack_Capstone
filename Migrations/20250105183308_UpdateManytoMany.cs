﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequioDemoTrack.Migrations
{
    /// <inheritdoc />
    public partial class UpdateManytoMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPurchase");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1176d10-b318-44e0-8ed8-fb0800dde53c", "AQAAAAIAAYagAAAAEAwTQDdQZKUx6o0G0jSlGpq8kpBxq7xIxdAsNbPd0bWo3vwDZzjRUsnohFMLLdPCnA==", "c56b4c38-67d0-4ce2-a0d6-a256f9f6f74d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPurchase",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "integer", nullable: false),
                    PurchasesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchase", x => new { x.ProductsId, x.PurchasesId });
                    table.ForeignKey(
                        name: "FK_ProductPurchase_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPurchase_Purchases_PurchasesId",
                        column: x => x.PurchasesId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0e4c711-6f83-4c87-892b-3445348768b5", "AQAAAAIAAYagAAAAEEacBp7HRiWQ/FeHA+gvZpuG+ueDWt7NjIN0xPYKLHJIuI9lvknjRVPFut1w/Naf8Q==", "e069b8a6-95a9-4e84-8401-7ff06918cf7b" });

            migrationBuilder.InsertData(
                table: "ProductPurchase",
                columns: new[] { "ProductsId", "PurchasesId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchase_PurchasesId",
                table: "ProductPurchase",
                column: "PurchasesId");
        }
    }
}
