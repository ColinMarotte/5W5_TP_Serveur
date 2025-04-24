using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class newcardpower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2b64f39-1e27-4c8b-ac73-20a0220a7ab2", "AQAAAAIAAYagAAAAEPOh/jnp3nVyp3QYYuj8tvJ3O9surdL9FHXRMA2u19rqG05JMB7RIaL2+KJ+b+JAag==", "4f67aefd-7610-400e-9105-3474d436ee87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "46130907-20f8-4ad4-ab13-115eeadad1f0", "38f281ae-f6f7-4f6c-b62c-0b7415ac7d2c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c33b2a56-f26d-4597-8511-1faf01b1e1b9", "8e2f1759-a8ae-44fb-b177-a4df2e56b258" });

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "CardPowerId", "CardId", "PowerId", "Value" },
                values: new object[] { 5, 4, 3, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "CardPowerId",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22fb3263-6c50-448f-b9d3-2b86918d8cfb", "AQAAAAIAAYagAAAAEElXnI0JX+++7cZxG64W2+SGy5myL2K1GJTHRxDPnaScdSyHKEHQLu3DEUHnj38IfQ==", "3f97d0fd-5acd-4a6a-800b-9a50a83129e0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ec9c6f3-01d3-4b46-864f-8a590f7f01d6", "56a567b5-5d17-458f-858e-38525cd26235" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "734b48d2-b5cb-4e54-a953-d0d9f6848799", "0ade55ee-83df-4241-a9fd-7ea262a51288" });
        }
    }
}
