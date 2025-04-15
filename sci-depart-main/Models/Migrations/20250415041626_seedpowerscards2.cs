using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seedpowerscards2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Powers",
                columns: new[] { "Id", "Description", "Icone", "Name" },
                values: new object[,]
                {
                    { 1, "Attaque l'adversaire.", "fa-bolt", "First Strike" },
                    { 2, "Inflige des dégâts au moment où la carte reçoit des dégâts.", "fa-spikes", "Thorns" },
                    { 3, "Rend des points de vie à une carte.", "fa-heart", "Heal" },
                    { 4, "Absorbe les dégâts.", "fa-shield", "Shield" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "671d392d-0025-4266-9ea5-2a6998fe9e16", "AQAAAAIAAYagAAAAEDJYGfPdpikBkL8+h1m93ARVUKP2fjpku5Jh3ui5RZV/CDBEeEAvSTMYxGBUyMX2Lg==", "5b404c51-70f3-4267-98d9-e3f0a0f59926" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "569e07fa-43e2-4da6-9fb8-3236411d9bc6", "e2a1fa15-feff-4254-bde8-bf70cfa88f10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "76aba3f0-64d4-4012-b27e-010c13893e31", "7abb6cb3-5a3f-4ed2-a3cc-0ff7f11af045" });
        }
    }
}
