using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Task : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3211c480-5545-44d6-b43b-cef433a37469");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "426e637a-4fee-446c-8e13-b4c6dd49cba9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0fbb700b-ee1c-47b4-ae1b-c38208fe862f", "9caee6b7-194c-466b-be2c-4d65912d34bb", "User", "USER" },
                    { "5c695b0b-f856-4fff-9a64-df270d12b0cf", "4cdbe14e-ae07-43f1-9440-491465d16bcc", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0fbb700b-ee1c-47b4-ae1b-c38208fe862f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c695b0b-f856-4fff-9a64-df270d12b0cf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3211c480-5545-44d6-b43b-cef433a37469", "0f79d2a8-b802-42da-a121-f16e6530230a", "User", "USER" },
                    { "426e637a-4fee-446c-8e13-b4c6dd49cba9", "03295547-d764-47b8-a4d9-68ce8140a3a5", "Admin", "ADMIN" }
                });
        }
    }
}
