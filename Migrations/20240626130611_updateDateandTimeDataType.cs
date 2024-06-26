using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetLembosa_Share_Rooms_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class updateDateandTimeDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "511e6af7-c351-4b81-8c99-9158122017bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea4cd3f9-de1f-4cde-9cf5-3d1aecd3e738");

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "Trips",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Trips",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "471bb3a5-4413-4478-b669-5cbdcd8f499c", null, "Admin", "ADMIN" },
                    { "63c51e44-0ac2-4e3f-a7f0-60ed6ffe9b85", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "471bb3a5-4413-4478-b669-5cbdcd8f499c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63c51e44-0ac2-4e3f-a7f0-60ed6ffe9b85");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Trips",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Trips",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "511e6af7-c351-4b81-8c99-9158122017bc", null, "User", "USER" },
                    { "ea4cd3f9-de1f-4cde-9cf5-3d1aecd3e738", null, "Admin", "ADMIN" }
                });
        }
    }
}
