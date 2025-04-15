using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seed5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d87fa16d-28a8-447a-b046-f6fbd919ec8d", "AQAAAAIAAYagAAAAEHfhTRB2BQix9PB28vZnxVXSGEQG+ZSSkKBy1TGpl+NxG3YkM/GDNxN4b+oLqB7wAQ==", "4bf02341-193f-45f6-951a-d0b5b86a1e17" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ed82d698-d4e4-437c-9e66-7d955199808a", "8884da9a-b3b6-4d5d-aae9-08cb83f2d5cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "88ee3c29-829f-4b0f-b02a-5d98a48054be", "7a669c98-b6bf-470f-b838-5fc31375b53c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27436bd9-5522-4d39-a062-5c8420fb6af4", "AQAAAAIAAYagAAAAEGBdyA8WWyBTVuDRQPz6OhGhHIporNsiB9OxGwMoAga+mHaflnSVt49RN5YJti7VlQ==", "6ea70151-a34f-4a90-976c-dd14a8ed90e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d025caab-405e-4c7c-bdc9-ab4277e21d74", "e3297458-b50f-4a15-90f9-01fe4a4f1fe0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38c0016d-412a-4468-a1f0-36fc8926a0da", "68c8d031-b379-4e60-8dd6-4a777d43f3e4" });
        }
    }
}
