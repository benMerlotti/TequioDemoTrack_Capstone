using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TequioDemoTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddedPurchaseProductSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bda2fe4f-487f-40b7-83c4-86cf416921b3", "AQAAAAIAAYagAAAAEF1g82hnUpXeRDWHSNPBX/CDJnkGNEj9FOph0XsudN4wo1Y4cjl5w01NeymTmT8pTw==", "bab414c0-1121-4fa5-99a5-a19469245047" });

            migrationBuilder.InsertData(
                table: "PurchaseProducts",
                columns: new[] { "Id", "ProductId", "PurchaseId", "Quantity" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 3, 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PurchaseProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PurchaseProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c1176d10-b318-44e0-8ed8-fb0800dde53c", "AQAAAAIAAYagAAAAEAwTQDdQZKUx6o0G0jSlGpq8kpBxq7xIxdAsNbPd0bWo3vwDZzjRUsnohFMLLdPCnA==", "c56b4c38-67d0-4ce2-a0d6-a256f9f6f74d" });
        }
    }
}
