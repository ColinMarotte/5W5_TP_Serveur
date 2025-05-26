using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class NewCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turn = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "PlayableCardStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayableCardId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayableCardStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayableCardStatus_PlayableCard_PlayableCardId",
                        column: x => x.PlayableCardId,
                        principalTable: "PlayableCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayableCardStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc5332d6-702b-4fe8-aee2-77f695371d94", "AQAAAAIAAYagAAAAEC1mJHg3Hom6v/wWy/CqzTcIz2l3xOA6AsUAGvMj85rvQRmovi6y+ua2zw2hcJV/XQ==", "7a927c43-47da-4379-98c2-570385488b44" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cf0913ba-c915-4a0d-b5f4-baea8986e48a", "2cf0bda6-dac2-4922-b920-55056308dbae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "04ddbaf3-8b19-4308-86f8-220ec7db9130", "9a23f70f-485e-4d1e-bfa7-0c000e6d9d07" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Attack", "Cost", "Health", "ImageUrl", "IsASpell", "Name", "Price", "Rarity" },
                values: new object[,]
                {
                    { 16, 6, 4, 10, "https://i.etsystatic.com/10964601/r/il/d4ad03/1093449052/il_fullxfull.1093449052_te57.jpg", false, "Chat Barbare", 100, 2 },
                    { 19, 0, 3, 0, "https://media.istockphoto.com/id/1428342232/vector/two-cats-wrapped-in-blankets.jpg?s=612x612&w=0&k=20&c=5N8CiQVBIfnpdHKcJyqGyQ6k8L3T4iKVjqisfPWZI3Q=", true, "Beddy-bye Boost", 200, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Cause des dommages à l'adversaire au fil du temps");

            migrationBuilder.InsertData(
                table: "Powers",
                columns: new[] { "Id", "Description", "Icone", "Name" },
                values: new object[] { 8, "Explose lorsqu'il meurt infligeant 2 de dégats à 2 chats adversaires", "💣", "Explosif" });

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "CardPowerId", "CardId", "PowerId", "Value" },
                values: new object[] { 10, 16, 8, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCardStatus_PlayableCardId",
                table: "PlayableCardStatus",
                column: "PlayableCardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayableCardStatus_StatusId",
                table: "PlayableCardStatus",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayableCardStatus");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "CardPowerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8a4108b-2bbb-421e-87cf-9cf84aafc71e", "AQAAAAIAAYagAAAAEMVB9i0k6q9P62Jwme124x17A1XFWpIy9f51gaLKAbeN7+aokBbE48upFuKbqFWaWw==", "2f858dd0-2bda-4bf2-8e8d-02aed457de9e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "49e6ee74-6cef-4a74-a2fb-587c1993a1b6", "eb95ceed-6125-4f09-82c9-f9e25c040fd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b2eb677a-8b15-483b-998c-b5ef684a2d18", "419df00a-5921-4fc4-8c69-063df056a5ef" });

            migrationBuilder.UpdateData(
                table: "Powers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Cause des au fil du temps à l'adversaire");
        }
    }
}
