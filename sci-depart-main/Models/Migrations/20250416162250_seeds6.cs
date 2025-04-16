using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Models.Migrations
{
    /// <inheritdoc />
    public partial class seeds6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Cards_CardId1",
                table: "CardPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardPowers",
                table: "CardPowers");

            migrationBuilder.DropIndex(
                name: "IX_CardPowers_CardId",
                table: "CardPowers");

            migrationBuilder.DropIndex(
                name: "IX_CardPowers_CardId1",
                table: "CardPowers");

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "CardId1",
                table: "CardPowers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CardPowers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardPowers",
                table: "CardPowers",
                columns: new[] { "CardId", "PowerId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f57a66c2-7796-400a-8be0-22eb53a41ad5", "AQAAAAIAAYagAAAAEGhfBoHvsl1OMBhrOisD27Kog5jh2CcmKaEDc9V+85GWlEgth0tdv3ESeLlxpnOvYA==", "e0695feb-c346-4218-a665-8eee7eee0cfd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User1Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e9c86b4d-1866-4d5e-b468-47753a7eacaf", "e3625399-e286-4651-a1be-852fd0d435a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "User2Id",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "464dcebf-1259-415d-a473-983d1f150bb5", "42033266-ed09-4b4b-8367-6f5bbf316ce3" });

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "CardId", "PowerId", "Id", "PowerId1", "Value" },
                values: new object[,]
                {
                    { 1, 1, 0, null, 2 },
                    { 2, 2, 0, null, 1 },
                    { 3, 3, 0, null, 5 },
                    { 4, 4, 0, null, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardPowers",
                table: "CardPowers");

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumns: new[] { "CardId", "PowerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumns: new[] { "CardId", "PowerId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumns: new[] { "CardId", "PowerId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CardPowers",
                keyColumns: new[] { "CardId", "PowerId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "CardPowers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CardId1",
                table: "CardPowers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardPowers",
                table: "CardPowers",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "CardPowers",
                columns: new[] { "Id", "CardId", "CardId1", "PowerId", "PowerId1", "Value" },
                values: new object[,]
                {
                    { 1, 1, null, 1, null, 2 },
                    { 2, 2, null, 2, null, 1 },
                    { 3, 3, null, 3, null, 5 },
                    { 4, 4, null, 4, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_CardId",
                table: "CardPowers",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPowers_CardId1",
                table: "CardPowers",
                column: "CardId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Cards_CardId",
                table: "CardPowers",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Cards_CardId1",
                table: "CardPowers",
                column: "CardId1",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPowers_Powers_PowerId",
                table: "CardPowers",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id");
        }
    }
}
