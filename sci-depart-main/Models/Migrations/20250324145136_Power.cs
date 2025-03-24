using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class Power : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardPowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    PowerId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPowers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPowers_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardPowers_Powers_PowerId",
                        column: x => x.PowerId,
                        principalTable: "Powers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_CardId",
                table: "CardPowers",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_PowerId",
                table: "CardPowers",
                column: "PowerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardPowers");

            migrationBuilder.DropTable(
                name: "Powers");

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
        }
    }
}
