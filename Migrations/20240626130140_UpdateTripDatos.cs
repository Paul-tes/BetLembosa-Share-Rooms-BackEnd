using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetLembosa_Share_Rooms_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTripDatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homes_Trips_TripDtoId",
                table: "Homes");

            migrationBuilder.DropIndex(
                name: "IX_Homes_TripDtoId",
                table: "Homes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80dc8fb9-ad6a-4acd-b137-08f9a4165c31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "837a7f38-cef5-4973-bd49-f74863f85871");

            migrationBuilder.DropColumn(
                name: "TripDtoId",
                table: "Homes");

            migrationBuilder.RenameColumn(
                name: "TripInfo",
                table: "Trips",
                newName: "HomeId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Trips",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Trips",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Trips",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "511e6af7-c351-4b81-8c99-9158122017bc", null, "User", "USER" },
                    { "ea4cd3f9-de1f-4cde-9cf5-3d1aecd3e738", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "511e6af7-c351-4b81-8c99-9158122017bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea4cd3f9-de1f-4cde-9cf5-3d1aecd3e738");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "HomeId",
                table: "Trips",
                newName: "TripInfo");

            migrationBuilder.AddColumn<Guid>(
                name: "TripDtoId",
                table: "Homes",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80dc8fb9-ad6a-4acd-b137-08f9a4165c31", null, "Admin", "ADMIN" },
                    { "837a7f38-cef5-4973-bd49-f74863f85871", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homes_TripDtoId",
                table: "Homes",
                column: "TripDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homes_Trips_TripDtoId",
                table: "Homes",
                column: "TripDtoId",
                principalTable: "Trips",
                principalColumn: "Id");
        }
    }
}
