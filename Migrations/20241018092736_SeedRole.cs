using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "152deea5-37a3-4e85-92a8-ff54f23a71de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffa34a2f-ad0e-45a0-8f50-fa2205380070");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3211c480-5545-44d6-b43b-cef433a37469", "0f79d2a8-b802-42da-a121-f16e6530230a", "User", "USER" },
                    { "426e637a-4fee-446c-8e13-b4c6dd49cba9", "03295547-d764-47b8-a4d9-68ce8140a3a5", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "152deea5-37a3-4e85-92a8-ff54f23a71de", "88457b56-1f49-4f27-8bda-079cd997dd23", "Admin", "ADMIN" },
                    { "ffa34a2f-ad0e-45a0-8f50-fa2205380070", "55503411-fe24-449d-99e9-e95482ea4e6e", "User", "USER" }
                });
        }
    }
}
