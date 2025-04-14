using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Seedpowercard2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be19699d-d16f-4317-a28b-d7f5b89d12ff", "AQAAAAIAAYagAAAAEPHIBbNrOh3mN+eYZusDdsrqBD31XaqMo1TkO6xgzABtNpAn4HOMC9hfD1ejkxkNVA==", "1dd58b6a-a8ae-463f-bcf8-39a517a76a92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4ab6f175-6dfe-4f3c-a596-70dacafba1da", "0ef599e3-47e8-4d8a-9215-6e2d24341817" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4a4479fa-df01-453d-8f6c-6d2eea2f78b2", "87412a31-3851-4d40-bb6d-b848e715a045" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1480f1a5-d68d-48b0-b63d-6142f6d846bf", "AQAAAAIAAYagAAAAEBwJB/p7CmIMN9fhPuh1m4QUCYfRpfCbKxBAVXL56ri3Mmk9ZleDzBix6pf5yQ0faA==", "1773b9fa-c516-46bb-8f1c-85e5666afea7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "168058ea-9095-42b4-823e-4672498b78cf", "93ce3074-984f-422c-8e40-3a39bdd52694" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "817b9647-859c-4e3d-b935-1e4ad8e3fa20", "412428c0-bb3d-46f7-8328-aee59a99ab19" });
        }
    }
}
