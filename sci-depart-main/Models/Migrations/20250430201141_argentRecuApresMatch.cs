using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class argentRecuApresMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b7c691e-de8d-4e23-9e6e-c1153d1b7f96", "AQAAAAIAAYagAAAAEJgg+K9uQVssSmrc5UX2XdSygWgxOO7TqeAM/cbcdJeWdjn9OHLQkWeynElUKpv6xQ==", "5cccd917-c9b0-4416-a42b-8c1c97cec115" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3ba8b387-d0f4-4e0e-94cc-47cc0741da08", "2b9ba3b6-4fc5-406c-912c-3bff0f967c38" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d40acea8-8e71-401d-850a-014c9d3b133a", "96c036a7-8455-48f6-ac43-567b47fcb370" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArgentRecuGagnant", "ArgentRecuPerdant" },
                values: new object[] { 40, 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f3bd26f-dd69-40bb-869d-f5dab87156e9", "AQAAAAIAAYagAAAAEG6SuZZr7Piwg+TPpH5TbyrSHlilEDbMI1qzKVW9xuSyw4eKUnYOGgFWKT9CROZ3dA==", "4581c059-c693-4aca-9137-01a281ec17ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "98010168-54ad-43ab-97d4-0bbe6e65f386", "f94bfb43-4e22-4cfa-8a28-082838826db0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "341c086d-48cb-49e8-8838-1007133f631a", "5207a939-a1db-4ac2-be28-95ab7aa8bf93" });

            migrationBuilder.UpdateData(
                table: "GameConfigs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArgentRecuGagnant", "ArgentRecuPerdant" },
                values: new object[] { 0, 0 });
        }
    }
}
