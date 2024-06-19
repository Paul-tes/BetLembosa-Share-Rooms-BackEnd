using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetLembosa_Share_Rooms_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19960006-7b02-4340-9ac6-717c3cf04314");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a103276d-d37f-4466-a2ad-2f014193607a");

            migrationBuilder.RenameColumn(
                name: "LocationType",
                table: "Homes",
                newName: "homeType");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a6dd6fb8-ce54-4f48-933c-8f0677ce6617", null, "User", "USER" },
                    { "c0af5074-5537-406f-8e55-da0ffba8517a", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6dd6fb8-ce54-4f48-933c-8f0677ce6617");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0af5074-5537-406f-8e55-da0ffba8517a");

            migrationBuilder.RenameColumn(
                name: "homeType",
                table: "Homes",
                newName: "LocationType");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19960006-7b02-4340-9ac6-717c3cf04314", null, "Admin", "ADMIN" },
                    { "a103276d-d37f-4466-a2ad-2f014193607a", null, "User", "USER" }
                });
        }
    }
}
