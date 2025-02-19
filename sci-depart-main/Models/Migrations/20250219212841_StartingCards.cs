using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class StartingCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a76ce3e5-ef64-4ae8-b72e-2e8991cb34e7", "AQAAAAIAAYagAAAAEI6MrC1bB7wMmq8z0m9zWkzY2dq6Spda60CtA7rENFb3JPXNAjV0xtw7vqJFTkRnaQ==", "296a226f-4080-4169-8a0d-4967ed1a9b4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b726efa6-2b4a-460f-8798-30783a0847fd", "88aa9efd-7d50-4226-b0a9-53e9eb036af5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9925a7d5-c3fa-46db-8650-121226d3ee43", "1595b1e5-aced-4e1b-a904-024cebd4705a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb7a5118-28c7-4092-8241-ed75b02de2f3", "AQAAAAIAAYagAAAAEK/TA/gMyakjdBRfQPVRJZ9kbyL2tNMD2reLlJCfYfb6s6pNVh4UsOQg6puElTrugw==", "ab67e82e-0399-4a11-8af6-58431962ad88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bf4662c5-48ae-4e41-b795-37bb285e01fe", "4cc25f93-218b-48e1-966d-92ecfb3cde94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9e7e36cb-0445-4092-83bf-607f53b4cffa", "03e4c89b-b88d-4f8f-ac25-f23dd86ac94e" });
        }
    }
}
