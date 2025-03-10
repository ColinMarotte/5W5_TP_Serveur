using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47420f64-29ff-45c4-89aa-6b4315f8d04d", "AQAAAAIAAYagAAAAEN5Jn5Kw8rBommqStWRYcZHINL+0pkeq82xjo/97/kSBN5/prcZ0jpS/i9N99d+j8Q==", "106db322-c072-442c-879c-ffd1ee538c03" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c00e2762-0c78-4f51-a959-f45489eec23e", "e0e6f7c0-e8b3-4be2-8487-a4b9d8f143dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e558fa23-21f1-4dd7-ad7b-b2eacddcb9d7", "13bc4761-6595-491b-b7a9-42d96f17d0ad" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "Name", "UserId" },
                values: new object[] { 3, "Admin", "11111111-1111-1111-1111-111111111111" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cd94229-3d67-4fd1-8662-0a31920cbbb4", "AQAAAAIAAYagAAAAELadEcuykd0JP2F1zAQQNlZktYrOptygt4L7C9e0szKN1FmKtrG3iNBecLH3IOvMDA==", "c4ffbb74-8dc5-4f8d-8305-80fb666629a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "01d698e2-ed71-4d38-bd97-e91de3b778e2", "182bbd21-afe4-491c-8246-a377d24e5bca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0567b1f5-aaeb-472e-88a9-c7b9e2961bf7", "ed036e38-e601-4d3d-87ae-21ef8552885e" });
        }
    }
}
