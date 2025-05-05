using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class argentRecuApresMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArgentRecuGagnant",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArgentRecuPerdant",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArgentRecuGagnant",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArgentRecuPerdant",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cd3d8377-bc12-402d-836b-b15633a55933", "AQAAAAIAAYagAAAAEA/ahZlEDdPyrZolyi4vPyW9stP8J5gHsWJyfjOH2CeJZd8Vmi1ZPUjpbHERMenrTQ==", "8b3ee40a-a42b-43c4-aa9e-371068875d68" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bacaef84-3f7d-4076-83a2-9d337981742d", "10cb490d-9cee-46a1-a99b-724733a956c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6475da35-c94b-49c4-a15c-3e742b81f422", "b548093e-cdac-48f6-a481-2422fdfac5d0" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArgentRecuGagnant", "ArgentRecuPerdant" },
                values: new object[] { 40, 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArgentRecuGagnant",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ArgentRecuPerdant",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ArgentRecuGagnant",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "ArgentRecuPerdant",
                table: "GameConfigs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6fdf3d76-6dcb-49b0-a205-90f4160d791a", "AQAAAAIAAYagAAAAEBGPHH8yudXnFLVibLc32Foii9Yg1O4IP1vzCKH8q9ykcIaeOBNYijlbDoB97cPmwA==", "e46b2e6e-7fdb-4eeb-aa90-180b7f152133" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f4def830-c0e3-45f0-90b3-dbe002caabef", "fccdbdc3-1f46-4bdb-982b-34f1aa810839" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "65f09066-e0c7-4bc6-bd15-3855800a48f0", "6f14752a-03a1-439c-8024-88657d0573e7" });
        }
    }
}
