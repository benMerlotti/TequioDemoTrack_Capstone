using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TequioDemoTrack.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97714cfa-176b-4179-8d77-b243891260cc", "AQAAAAIAAYagAAAAEHyUNQ/OuF/CyCCoFqLloMbffc6UZPi4RHgyvJWeTdKsM9ZN98yNSTYDidBxnKYcTQ==", "35e68d2b-40eb-4091-b113-d1794dc677b8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bda2fe4f-487f-40b7-83c4-86cf416921b3", "AQAAAAIAAYagAAAAEF1g82hnUpXeRDWHSNPBX/CDJnkGNEj9FOph0XsudN4wo1Y4cjl5w01NeymTmT8pTw==", "bab414c0-1121-4fa5-99a5-a19469245047" });
        }
    }
}
