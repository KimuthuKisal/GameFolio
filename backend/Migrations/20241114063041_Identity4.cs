using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Identity4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cad0c3ad-f950-414f-b585-aa8a42fc261e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8d5fa3f-15b1-43e9-bd9b-bd6ea55facbe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "112af1c4-2688-4ef0-bc0e-83061f2337a8", null, "admin", "ADMIN" },
                    { "fc9088bf-2931-4563-9a69-f58892351807", null, "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "112af1c4-2688-4ef0-bc0e-83061f2337a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc9088bf-2931-4563-9a69-f58892351807");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cad0c3ad-f950-414f-b585-aa8a42fc261e", null, "user", "USER" },
                    { "d8d5fa3f-15b1-43e9-bd9b-bd6ea55facbe", null, "admin", "ADMIN" }
                });
        }
    }
}
