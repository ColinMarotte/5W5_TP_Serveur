using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class ConfigDecks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NbCardsMaxInDeck",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NbDecksMax",
                table: "GameConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10cc1b3d-6a8c-48d3-a414-5eb1964c3fa0", "AQAAAAIAAYagAAAAEJsvZA0wsJZmhHAhFiNH78sYTQIwMJGfTYpmPO1Hpw3LRJ48yIxvZaDsTXZdYV79VA==", "29348e69-fc7a-4065-ac51-cec43b807aee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "61c81e29-c73d-49b1-9107-aa17ddd06608", "12ee86a3-51ed-4366-8da1-09f1b586cd1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1fac4c10-2181-4ef8-a1d4-cb67ed89149f", "ef724174-5eca-4916-8eb8-8b6abe2c1b76" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "NbCardsMaxInDeck", "NbDecksMax" },
                values: new object[] { 10, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NbCardsMaxInDeck",
                table: "GameConfigs");

            migrationBuilder.DropColumn(
                name: "NbDecksMax",
                table: "GameConfigs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06bcd834-931f-498d-ba04-8dd82f2b9550", "AQAAAAIAAYagAAAAEKSTqsYYiXjNEZElh7RLlvofBsZEt7QvETokAUDO3hGXy71/1seG+Qu4HB6oDuZvoQ==", "d5faa97e-b560-417d-9107-8cebd3f42a95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "05bf7df2-ef13-496a-83d9-f074773e2ef7", "ee1091d5-707f-482f-af41-8ebcdfb3bdad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5db8a036-51cd-459a-8428-dded27243e5f", "3fa307a0-c69e-4c2d-9bca-28a826d2f151" });
        }
    }
}
