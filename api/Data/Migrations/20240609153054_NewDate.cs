using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d754dba-68f3-47bc-b3a5-20a68934bb22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10e6d9fe-aad4-4408-b1c9-d9477a1534c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25c2d8be-1e49-4fb1-8bef-0c4efe930dd2", null, "User", "USER" },
                    { "62dccc35-e0e0-464e-850f-24e8236006cb", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25c2d8be-1e49-4fb1-8bef-0c4efe930dd2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62dccc35-e0e0-464e-850f-24e8236006cb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d754dba-68f3-47bc-b3a5-20a68934bb22", null, "User", "USER" },
                    { "10e6d9fe-aad4-4408-b1c9-d9477a1534c2", null, "Admin", "ADMIN" }
                });
        }
    }
}
