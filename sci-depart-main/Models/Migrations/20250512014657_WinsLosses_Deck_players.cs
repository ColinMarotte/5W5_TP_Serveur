using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class WinsLosses_Deck_players : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalLosses",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalWins",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Losses",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "Decks",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TotalLosses", "TotalWins" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TotalLosses", "TotalWins" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TotalLosses", "TotalWins" },
                values: new object[] { 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalLosses",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "TotalWins",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Losses",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "Decks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6485689-f000-4e5b-b224-56ec5482a63f", "AQAAAAIAAYagAAAAEM9g1r447VSlU+6Lg3Mp2Q5pLtPTBMiAr95OKt9xwJPAe+Gy5tq2eFR5r2Q80634Ww==", "e2c1bb9f-9841-48e0-815b-51fd91b98985" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "24ff9cad-bfce-4943-b862-57da3d519597", "1c967199-33da-4c58-bd86-8009afbde80d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d23bbd05-ef42-44c7-867c-d9e99b9f9e8e", "31c73799-157b-479c-88d1-406fa0f44186" });
        }
    }
}
