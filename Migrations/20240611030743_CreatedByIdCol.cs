using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetLembosa_Share_Rooms_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CreatedByIdCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_AspNetUsers_CreatedById",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_CreatedById",
                table: "Homes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6dd6fb8-ce54-4f48-933c-8f0677ce6617");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0af5074-5537-406f-8e55-da0ffba8517a");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Homes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Homes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1edf201a-dc1e-4ff3-bb7d-5779612c6c64", null, "User", "USER" },
                    { "257caec2-fbb3-4f9f-8c37-b11e94c79509", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_AppUserId",
                table: "Homes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_AspNetUsers_AppUserId",
                table: "Homes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_AspNetUsers_AppUserId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_AppUserId",
                table: "Homes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1edf201a-dc1e-4ff3-bb7d-5779612c6c64");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "257caec2-fbb3-4f9f-8c37-b11e94c79509");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Homes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Homes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6dd6fb8-ce54-4f48-933c-8f0677ce6617", null, "User", "USER" },
                    { "c0af5074-5537-406f-8e55-da0ffba8517a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_CreatedById",
                table: "Homes",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_AspNetUsers_CreatedById",
                table: "Homes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
