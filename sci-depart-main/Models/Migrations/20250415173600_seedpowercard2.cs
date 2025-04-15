using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seedpowercard2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01e193db-61be-4d7a-8fd1-eff08fe845db", "AQAAAAIAAYagAAAAEMBoHT5cEn4cB6TMvG84EBRaOBrXBwJ8NVZQQSTmGBH1OFteI6YpO/R498q29zZZ2w==", "8b1a2e39-3144-486d-8e96-a79d57456ee7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c6d90577-9ffe-46c2-9809-a1618574169b", "229afa75-9476-424b-8f94-84a92f6c843d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e367a1a7-a143-4379-bd0a-6b4fbee8d1d4", "492c7089-c506-4d42-83c4-2d73ba3c2056" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92c59cda-43f4-4d4b-b384-4079d0b38bc5", "AQAAAAIAAYagAAAAEImpFAWBmCtvxFgClpCUdime2m77igIwbpi+VapVFFRHkkeDD3msuFXJpHT2g1Qmhw==", "a04fa49c-56ef-4ad1-99e3-7f565a00ab20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b9307ecb-7e4b-404e-9e49-47a6c6f0d709", "5c9b6219-03c3-4695-bf7d-d3a8666dce7f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "acd1e959-3dff-427b-bed2-550498ae0626", "fb111403-c649-47fb-82c7-f65485a51c05" });

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "Id", "CardId", "PowerId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 3, 5 },
                    { 4, 4, 4, 3 }
                });
        }
    }
}
