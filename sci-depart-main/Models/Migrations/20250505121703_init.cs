using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c9c6265-1387-45fb-8d28-082c71b80f76", "AQAAAAIAAYagAAAAEAyw95xNScP7gLwCc+bgxKnA/G1zwvIdSUs6xLoob3tmuEx/JQbmZYjW/9OCf/zEsA==", "3279b41d-d899-418a-b03c-e5c901f43f85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "65e4220c-30ec-41f5-85f9-630369bd25f4", "e99cedca-ee35-44cd-a92b-ede77905a9b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41f02f91-0072-4b53-8d14-0e32aacb9c00", "25524df3-6a0b-4581-aed1-8a4d013073a9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dcf6386-5f38-4aa3-82d2-bc6c3ee23443", "AQAAAAIAAYagAAAAEHika1+ehB+U9NVh1izw6+mLj5PMmH+tAqmMrO+F7tL0AyFkSBQsmTF0mmZg7e+O6g==", "97596408-b502-4640-83f3-e1ab70cb1edf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e45f7c9b-5a26-4258-8786-bd3fbe21fcc3", "07b24c51-d4fe-4665-89f6-d966e08c9b25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d4d47e9e-a48b-4813-8f57-148cf16bd71b", "fd5577f6-e6d4-4779-b890-a4a7c82f1ec7" });
        }
    }
}
