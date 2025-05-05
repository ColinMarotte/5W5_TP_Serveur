using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class spellsAndNewSartingCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8a4108b-2bbb-421e-87cf-9cf84aafc71e", "AQAAAAIAAYagAAAAEMVB9i0k6q9P62Jwme124x17A1XFWpIy9f51gaLKAbeN7+aokBbE48upFuKbqFWaWw==", "2f858dd0-2bda-4bf2-8e8d-02aed457de9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "49e6ee74-6cef-4a74-a2fb-587c1993a1b6", "eb95ceed-6125-4f09-82c9-f9e25c040fd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b2eb677a-8b15-483b-998c-b5ef684a2d18", "419df00a-5921-4fc4-8c69-063df056a5ef" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17,
                column: "Rarity",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77e737a4-4968-4143-8ce3-7731b8fcc198", "AQAAAAIAAYagAAAAEOdB12AuhgQT+FlKtlTgxYxtJn18xPh+RD08zuGo4HOQjV09B+XCn4A9XPJj4nsXkg==", "6519f3e1-08b0-4eaa-a6a0-6cd9c7b8c509" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c84c4a7d-217c-4be7-a025-4b9d07eef13b", "2ed78c7b-655a-401b-b6b6-aa8446eef0e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "27c4b466-bb05-453e-b5f6-352fc9cfcac6", "2433ba0e-2bbd-4de7-ae39-0c1fed3ae0b4" });

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 17,
                column: "Rarity",
                value: 0);
        }
    }
}
