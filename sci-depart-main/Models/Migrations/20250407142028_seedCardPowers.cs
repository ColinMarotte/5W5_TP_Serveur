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
                values: new object[] { "ff8ab12a-3fe8-4878-b4a8-cd60fcc71bcf", "AQAAAAIAAYagAAAAEGRx2xIunsJSrqchVRKDCim5/A2EKtk1Fbt027rlI20hLPAOigynZNGAsQz5JOyBlA==", "56b1d8b2-9324-4fa7-949d-8a6804b872c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "502fc178-e235-4ea1-9328-408b0c7ae707", "03c4b614-031f-476e-b082-5e52256c7cb1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "48eace22-928f-47ba-91df-5d9a5efcb7f1", "4c1b779c-69c2-4e19-a403-48c1ee05f8c3" });

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Attaque l'adversaire.");

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Absorbe les dégâts.", "Shield" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Attaque l'adversaire");

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Absorbe X dégâts.", "Shield X" });
        }
    }
}
