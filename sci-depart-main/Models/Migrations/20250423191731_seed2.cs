using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3318b2f0-e913-4b02-9cb9-22d00de1ff0a", "AQAAAAIAAYagAAAAEDd088OmRt3Rq9v1YY+RrB3D76Vp4nf03plskzNpMSwHSWQ+VBanQybXcTSS4bqMAw==", "71f919c0-aaa8-4354-9de5-70ba98a27909" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a98c82c-5187-4e9d-ba21-f03b0a03c232", "d1a93588-c321-4e96-a613-c058c3a299d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "45b590a2-a9c4-427d-b024-3b7e24e8f077", "4b70ce9c-8c43-469a-a380-3ca6f5e3d376" });

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "CardPowerId", "CardId", "PowerId", "Value" },
                values: new object[] { 6, 1, 3, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "CardPowerId",
                keyValue: 6);

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
        }
    }
}
