using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class morePowersAndCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "171952c2-eb44-4a3c-ad53-2399caa9cf0f", "AQAAAAIAAYagAAAAEF9Is98QKtsfu5vvvhFBCYgXUi9pHyrx5wANe3xPq9JiTuzGzMn5Q0Wq1e3YfIYRBg==", "0a2d91b0-198e-4d69-828e-77f26ae5f8c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "caadc9e8-2500-4576-ac92-2dbe88a9fed0", "cd2efcc2-6408-4b3a-aec1-f15de19ab33a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef882c8e-9c3d-4aba-a473-e5027e82224e", "261155c8-be56-46b8-822e-fbaf4ef0e802" });

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "CardPowerId",
                keyValue: 7,
                column: "Value",
                value: 0);

            migrationBuilder.InsertData(
                table: "StartingCards",
                columns: new[] { "Id", "CardId", "CardId1" },
                values: new object[] { 10, 13, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StartingCards",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27ffcda4-e472-49ba-ae3f-f998a29aaeb0", "AQAAAAIAAYagAAAAELGrsPSyzKiRR7Xut4OKujj8ZxIEEsdGItpADymOc1Y5+xWaS8U9O9S+zrjenpQ9jw==", "572058ed-9d9d-4bb9-9a35-e0b30d365043" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a4db3d1d-47de-4fc4-b773-5e2413fbae77", "32ddc622-7681-4e19-a124-fa51ce355412" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c9cb1488-cd75-4788-a7aa-150fe30e7dc8", "f24aed8f-c493-49e4-9f85-d2473c31c7eb" });

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "CardPowerId",
                keyValue: 7,
                column: "Value",
                value: 4);
        }
    }
}
