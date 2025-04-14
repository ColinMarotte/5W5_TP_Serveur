using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Index",
                table: "PlayableCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d206b794-c2a7-44ac-8296-90dc1219110e", "AQAAAAIAAYagAAAAEF/qQk+B1x2PgBAwS0OzbJhpGFUk8Sa56Q7RhRDf+ptuCWfq6qh2T0NmOhnymu8wLg==", "e1b93a58-72e6-4fa6-926d-5e0fa63a8288" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8374ae2d-0374-4a62-9486-127d0e693e38", "c8f92384-4288-4ed3-a544-d2c9beb22a99" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef799a63-06e5-4d07-a2b1-6fe51aa9ef3c", "b5c751b0-b570-4d27-b312-792efd91aec5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Index",
                table: "PlayableCard");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53916e06-601b-462e-b5e0-5cb4a63ef514", "AQAAAAIAAYagAAAAEOB2oLjQTC6usN9EAvI1ghCSCA7/6ZQmQ4VTCjJ0PxhmzLl0x+UNXgGOx6JKIcKIEQ==", "270b4abd-ac79-423b-924a-5f0b17474e62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4bc002fe-3b00-4203-b7b2-a1530b80cfcd", "7ded2a21-31ae-4ee0-8264-ca61bd87e31c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8ef01182-3944-4429-8e87-d7cbe340dba9", "ed1ba9f3-842b-42c1-86aa-c7cbd7a7c6d2" });
        }
    }
}
