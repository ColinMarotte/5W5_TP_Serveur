using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class MatchPlayerData_Deck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "MatchPlayersData",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db7cda65-d4bb-4f3b-9db4-82cfc937b719", "AQAAAAIAAYagAAAAEB2I4VrzMt1Ut9r/tjd5J681nOojkzrHxIk4eZmAhqhiUULehYq4zqWdC620hmSGBg==", "e2426f00-2029-4d82-b2ed-e3fd09d2c032" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2c39d68d-caa5-4f40-a723-eb27a42b5c29", "d23802ac-47a1-40bd-81fa-1a5781185f3b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bbe6a8f7-d378-4a5c-8a8d-2c640d338edd", "35afd0d6-4c73-4d8b-a321-deaf805b6c0f" });

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayersData_DeckId",
                table: "MatchPlayersData",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchPlayersData_Decks_DeckId",
                table: "MatchPlayersData",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchPlayersData_Decks_DeckId",
                table: "MatchPlayersData");

            migrationBuilder.DropIndex(
                name: "IX_MatchPlayersData_DeckId",
                table: "MatchPlayersData");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "MatchPlayersData");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6595bf4c-4088-4e2c-8fc8-092110a4bfd5", "AQAAAAIAAYagAAAAEEZ1iq3M773g7GDLZCd6NoWTEyFeplgkG1jCAP59QgvCD7bAvpJaViWM36QLJAAoFA==", "f8d60051-ac83-489d-a4c4-9137c6c3fe7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ceb981c3-d272-44e3-8a90-5fa5883cba16", "531edfc1-6a67-4360-b119-dfe55930648a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0fc6e655-8f1c-4173-bc2f-f178a70bc897", "abdca175-37a8-4e78-988c-1535b18f239f" });
        }
    }
}
