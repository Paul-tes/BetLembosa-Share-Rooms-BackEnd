using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetLembosa_Share_Rooms_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class commentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b140d68f-19ae-4ecf-985c-51b60d37e7a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2e0c325-a593-489f-ab7e-7474695d077b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80dc8fb9-ad6a-4acd-b137-08f9a4165c31", null, "Admin", "ADMIN" },
                    { "837a7f38-cef5-4973-bd49-f74863f85871", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80dc8fb9-ad6a-4acd-b137-08f9a4165c31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837a7f38-cef5-4973-bd49-f74863f85871");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b140d68f-19ae-4ecf-985c-51b60d37e7a7", null, "Admin", "ADMIN" },
                    { "f2e0c325-a593-489f-ab7e-7474695d077b", null, "User", "USER" }
                });
        }
    }
}
