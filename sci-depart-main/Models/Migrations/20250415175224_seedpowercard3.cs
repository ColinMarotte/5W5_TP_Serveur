using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seedpowercard3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers");

            migrationBuilder.AddColumn<int>(
                name: "CardId1",
                table: "CardPowers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerId1",
                table: "CardPowers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "815ed1c7-d383-4641-8098-75f1851eabae", "AQAAAAIAAYagAAAAEODKta9FGoa7e8ceOIabvynOZZxrOBlEoxLtsdg7ltPsAutEOjx/6ZnlOH7b9bsbCw==", "76dba0a5-abfa-49d6-ac1e-b259d8e2c1f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6d539742-6d81-4667-978a-9c11a69e57b8", "29fa813f-4309-4a32-813b-ee7556379f05" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "51e13703-af07-4beb-bfba-1e8463ba0b53", "1130ab80-1eb3-4151-9b63-d8346293156c" });

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CardId1", "PowerId1" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CardId1", "PowerId1" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CardId1", "PowerId1" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CardId1", "PowerId1" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_CardId1",
                table: "CardPowers",
                column: "CardId1");

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_PowerId1",
                table: "CardPowers",
                column: "PowerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Cards_CardId1",
                table: "CardPowers",
                column: "CardId1",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Powers_PowerId1",
                table: "CardPowers",
                column: "PowerId1",
                principalTable: "Powers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Cards_CardId1",
                table: "CardPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Powers_PowerId1",
                table: "CardPowers");

            migrationBuilder.DropIndex(
                name: "IX_CardPowers_CardId1",
                table: "CardPowers");

            migrationBuilder.DropIndex(
                name: "IX_CardPowers_PowerId1",
                table: "CardPowers");

            migrationBuilder.DropColumn(
                name: "CardId1",
                table: "CardPowers");

            migrationBuilder.DropColumn(
                name: "PowerId1",
                table: "CardPowers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21ae0708-3fa3-44b8-a7d3-1a2b3cc6ddbc", "AQAAAAIAAYagAAAAEC42Ez3A4D6D8ciHD46zigsXhSGN93DHFPsIDym/EV+KJAs7aHh6MQovjWIDv3vjSg==", "dbe52315-400d-4763-a54f-4e518dd6c6b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "457b2da3-46f1-4675-ba07-448cc75eee88", "a0e6f430-83da-4dc0-9111-78c0983cce04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d966b86a-4d95-4a06-aa36-10212101f1bf", "773dd1fc-cb97-4d1a-a6fe-d0cb43690120" });

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
