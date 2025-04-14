using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Seedpowercard2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d71d98c2-0503-4f9b-a7a6-79f2daf75ee6", "AQAAAAIAAYagAAAAED+Zm95vQJP2oCipS5efPBMVBK5ewbJ8Wzy0eqTzAxDJ8DI+pn2FzTidEMc9T4Qi6g==", "b58225ca-83cd-445d-9666-55b7dc4a7d7c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0d5ebe7f-8696-4cbc-a0be-f441203e6b2c", "52ed84d1-5588-4668-a0bf-24c030eddf04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fc3fac0f-581c-43e0-8035-57ab0731334c", "32eeadba-e421-44e6-8b0d-1bef5230c406" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "d22558ee-1ce7-41f7-9b26-e68899fac6e3", "AQAAAAIAAYagAAAAEBax8vSOoEJTWp4fiwWaUngc2sAQahTUf6Z6Z8PbyPJMSE0yqReyHdMrWDvFN6ZJ3w==", "3bc86918-6572-4cd2-ba25-2c5f213d1e81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "47321a20-4113-4469-826e-af8c162ee8c0", "108ed3ec-3a74-4e14-973c-49035f173b0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5435249-7a1b-4458-96b8-ac2b6298c72e", "b8ad3775-ce31-4ad1-b1f8-e077e64548f2" });
        }
    }
}
