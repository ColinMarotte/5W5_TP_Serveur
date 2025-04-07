using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seedCardPowers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e8a2cfb-bdb3-4094-aba9-403acf786496", "AQAAAAIAAYagAAAAEEpUSusf6AUHabU5HipbJIzjxH2lYqHWZ+txhRWSNWLlr/qr9QUGsdDCEdIM8nvFQA==", "41359d38-43bc-41f7-9ad8-b17346303141" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "deadfaf1-52f0-4511-9348-7e438f745867", "cab0054a-4cd0-45e6-a426-7d749543d921" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bc6024df-688b-4de5-aa16-a4394a71adfb", "2a388555-841b-4284-ad72-4f6d52fcff67" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4dda86f4-f5c7-4500-880f-41a1ef735d3e", "AQAAAAIAAYagAAAAEGv9t+fHqNZH99kkMBkN8CgyEo2PqzVDKDnOmYM0/WamBPFlHPC76dS1G0Xo83BNlQ==", "06c7c814-97db-4168-9c3f-81d45b5549b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5bc8b5fb-6e72-4aa6-8c1e-0ca34a35e87a", "b9a07b3e-7360-43cc-bd87-6acdae34f8fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "401088a7-5b58-4315-af8e-d6ccf8694809", "661cc8a7-0705-4f91-9819-848b6f285d8f" });
        }
    }
}
