using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "586584ab-1a13-41cc-b0ce-ad199e4d0728", "AQAAAAIAAYagAAAAEBge7pFRrgrbV6kwnLm0/6Rjq9F5S46Hfji3sn9D55/EpnmB5GF5pXthUWTfV4qJ9w==", "e32f64e8-4368-4682-a4d5-61f7d775c7ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6ef373b6-030c-4039-acff-7b2b881644de", "abfa3dbb-740a-46da-b4b1-ec9bdb6c39d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "469c9018-d6fa-44c0-89c7-a614ebba8d4f", "5f3cee06-f600-417a-bb2c-fff01e655f35" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
