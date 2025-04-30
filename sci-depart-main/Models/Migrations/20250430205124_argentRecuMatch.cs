using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class argentRecuMatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArgentRecuGagnant",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ArgentRecuPerdant",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArgentRecuGagnant",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ArgentRecuPerdant",
                table: "Matches");

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
        }
    }
}
