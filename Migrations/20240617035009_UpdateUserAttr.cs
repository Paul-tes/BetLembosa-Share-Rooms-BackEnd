using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetLembosa_Share_Rooms_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserAttr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b8b83e2-72a2-4d5f-b834-d657446a8730");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d3726dc-779d-4750-b98b-3baf65a71444");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Wishlists",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Trips",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Homes",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b140d68f-19ae-4ecf-985c-51b60d37e7a7", null, "Admin", "ADMIN" },
                    { "f2e0c325-a593-489f-ab7e-7474695d077b", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_AppUserId",
                table: "Wishlists",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_AppUserId",
                table: "Trips",
                column: "AppUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_AspNetUsers_AppUserId",
                table: "Trips",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlists_AspNetUsers_AppUserId",
                table: "Wishlists",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_AspNetUsers_AppUserId",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlists_AspNetUsers_AppUserId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Wishlists_AppUserId",
                table: "Wishlists");

            migrationBuilder.DropIndex(
                name: "IX_Trips_AppUserId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Homes_AppUserId",
                table: "Homes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b140d68f-19ae-4ecf-985c-51b60d37e7a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2e0c325-a593-489f-ab7e-7474695d077b");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Wishlists");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Homes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1b8b83e2-72a2-4d5f-b834-d657446a8730", null, "User", "USER" },
                    { "1d3726dc-779d-4750-b98b-3baf65a71444", null, "Admin", "ADMIN" }
                });
        }
    }
}
