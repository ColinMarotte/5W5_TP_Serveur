using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seedpowercards4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "6042fc51-d8e8-4fd0-819c-009e016968ff", "AQAAAAIAAYagAAAAEMLFoJ3AZUCKKjScZ/C1EvrtCaF2lkWO52kH7EPOlXM3Ov5bQj0kuQv34DiFvLqBYA==", "b23ed14c-96aa-4a6b-b12b-0975e205a3b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "84a7d2be-af93-4586-98bc-12713ba08ef6", "3aa9390c-2324-4891-b6c9-39f918fa6e03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f0d75711-ddd1-4099-bfde-d7379dd0af79", "b99b15b4-270f-4d7a-9ead-725265537385" });

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Value",
                value: 0);

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "Value",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Value",
                value: 1);

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "Id", "CardId", "CardId1", "PowerId", "PowerId1", "Value" },
                values: new object[,]
                {
                    { 3, 3, null, 3, null, 5 },
                    { 4, 4, null, 4, null, 3 }
                });
        }
    }
}
