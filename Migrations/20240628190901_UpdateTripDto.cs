using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetLembosa_Share_Rooms_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTripDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "471bb3a5-4413-4478-b669-5cbdcd8f499c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63c51e44-0ac2-4e3f-a7f0-60ed6ffe9b85");

            migrationBuilder.AddColumn<string>(
                name: "HostName",
                table: "Trips",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Trips",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3611da9e-b6cf-45c2-b0a9-56493c92b544", null, "User", "USER" },
                    { "a8840d19-95ad-4130-ae4d-82680ec46387", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3611da9e-b6cf-45c2-b0a9-56493c92b544");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8840d19-95ad-4130-ae4d-82680ec46387");

            migrationBuilder.DropColumn(
                name: "HostName",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Trips");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "471bb3a5-4413-4478-b669-5cbdcd8f499c", null, "Admin", "ADMIN" },
                    { "63c51e44-0ac2-4e3f-a7f0-60ed6ffe9b85", null, "User", "USER" }
                });
        }
    }
}
