using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class GameConfigSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdfc6721-11ab-4135-bde2-87d2372a7729", "AQAAAAIAAYagAAAAEFDh87dPoaYyjRJZGb8xv72+yMXugLADpSed2B9ynuZwDAphorBLVQh5SYXTQc6M+A==", "c820c092-f862-4417-a626-af840afb6497" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d1cafc93-0ae7-43a8-9ab6-c4f9b561cf35", "e7ce7110-bbd0-478b-b3ad-123579a06c83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f9dd9b5b-b24a-4020-944b-d044f5d439a7", "e73c0b71-f749-4360-bdb3-3ca29a53155b" });

            migrationBuilder.InsertData(
                table: "GameConfigs",
                columns: new[] { "Id", "NbCardsToDraw", "QtyManaPerTurn" },
                values: new object[] { 1, 4, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ebd32dd-79de-43ab-9f87-d989cc775205", "AQAAAAIAAYagAAAAEGtFXpM9wq8RJa/oG7+P1LnxJrdI1o6S8qedebe1+gHjq+RaRi9pN/B2aesN3zoVgQ==", "4df78f49-0c5a-4ca1-a315-b9e93207e8d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4771c939-7269-4922-a216-fe5208635126", "fbe90098-37f9-4c05-9a13-7ad89edf312b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "94b9e6e5-7f18-48c2-8a88-35a33e7533e2", "c06eb0d0-b421-4db8-b549-9e87bd840457" });
        }
    }
}
