using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seedPowers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Description", "Icone", "Name" },
                values: new object[,]
                {
                    { 1, "Attaque l'adversaire", "fa-bolt", "First Strike" },
                    { 2, "Inflige des dégâts au moment où la carte reçoit des dégâts.", "fa-spikes", "Thorns" },
                    { 3, "Rend des points de vie à une carte.", "fa-heart", "Heal" },
                    { 4, "Absorbe X dégâts.", "fa-shield", "Shield X" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06bcd834-931f-498d-ba04-8dd82f2b9550", "AQAAAAIAAYagAAAAEKSTqsYYiXjNEZElh7RLlvofBsZEt7QvETokAUDO3hGXy71/1seG+Qu4HB6oDuZvoQ==", "d5faa97e-b560-417d-9107-8cebd3f42a95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "05bf7df2-ef13-496a-83d9-f074773e2ef7", "ee1091d5-707f-482f-af41-8ebcdfb3bdad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5db8a036-51cd-459a-8428-dded27243e5f", "3fa307a0-c69e-4c2d-9bca-28a826d2f151" });
        }
    }
}
