using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class addPouvoirEtSortAuChoix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0a899d4-0e7d-4475-816a-aab5b8394b18", "AQAAAAIAAYagAAAAEF8dlp7QjDkzybV9+nneUY7WBKyrt3YoZmHWxxwzHj2aygxezCtPb+lzzEda4pdDyQ==", "3d4a5eef-3375-4967-96b9-9027eb27b028" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "41dfbfa7-538d-4807-836d-f458f595ff99", "6da2d8b0-b76f-4f2e-bb53-314badc6dc0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b843f7ad-7dfe-4c22-9cc9-370839e59511", "951ff88c-88ca-4c7d-be16-b4068d9e3331" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0dbc3d81-649f-440e-9bae-52731a66be43", "AQAAAAIAAYagAAAAEI2VkW8X1I7mFQiNEJSylBphNxXlQFSOT6N05bQcZm0Uu5xfIXRLXFl/e/xl9nCd7A==", "a5f29579-eeda-454b-bad9-7340bc49a2f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff2b853c-9473-4ebf-8a43-2a3c0b6e8645", "0a8904f3-7315-4b95-b1ef-8ac75d980592" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7ad4a0dc-751a-4c82-8268-e9066c0f6077", "f750719f-aa37-45b7-bb07-0271ae976f4f" });
        }
    }
}
