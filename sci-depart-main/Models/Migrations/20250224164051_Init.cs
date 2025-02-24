using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NbCardsToDraw = table.Column<int>(type: "int", nullable: false),
                    QtyManaPerTurn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameConfigs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ebd32dd-79de-43ab-9f87-d989cc775205", "AQAAAAIAAYagAAAAEGtFXpM9wq8RJa/oG7+P1LnxJrdI1o6S8qedebe1+gHjq+RaRi9pN/B2aesN3zoVgQ==", "4df78f49-0c5a-4ca1-a315-b9e93207e8d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4771c939-7269-4922-a216-fe5208635126", "fbe90098-37f9-4c05-9a13-7ad89edf312b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "94b9e6e5-7f18-48c2-8a88-35a33e7533e2", "c06eb0d0-b421-4db8-b549-9e87bd840457" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameConfigs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82715421-a322-430a-a52b-d37a394eb7b1", "AQAAAAIAAYagAAAAELjV8ptmDr/fbAj4kE5VEvVhJvTudH/7s/SL3bdhnBHp0XMvBw3bEXilxIIKW8efoA==", "3d1d4131-4bcd-42e8-b7f5-809127f80910" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de7b60b6-21d7-4b3e-8c51-ed50638b3bda", "9fa6443a-fd0b-4abe-8d87-ee9ba8fff00b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7ec5855e-709b-43d5-9f23-14858f2e9eea", "972197aa-78eb-4036-bb1f-fc951d808c9c" });
        }
    }
}
