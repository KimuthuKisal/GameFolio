using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_Admin1UserId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_Admin2UserId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_Admin3UserId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_OwnerUserId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_Admin1UserId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_Admin2UserId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_Admin3UserId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_OwnerUserId",
                table: "Organizations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25704904-71a8-40da-aeac-6f6f577cc484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa9bfac-f76f-41db-86b2-fc5feb3b8eef");

            migrationBuilder.RenameColumn(
                name: "OwnerUserId",
                table: "Organizations",
                newName: "Owner");

            migrationBuilder.RenameColumn(
                name: "Admin3UserId",
                table: "Organizations",
                newName: "Admin3");

            migrationBuilder.RenameColumn(
                name: "Admin2UserId",
                table: "Organizations",
                newName: "Admin2");

            migrationBuilder.RenameColumn(
                name: "Admin1UserId",
                table: "Organizations",
                newName: "Admin1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d50ccb0-f44b-4faa-97e3-38defbccb8e7", null, "user", "USER" },
                    { "c3968914-fb60-4674-89f7-4a5eea6afaf1", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d50ccb0-f44b-4faa-97e3-38defbccb8e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3968914-fb60-4674-89f7-4a5eea6afaf1");

            migrationBuilder.RenameColumn(
                name: "Owner",
                table: "Organizations",
                newName: "OwnerUserId");

            migrationBuilder.RenameColumn(
                name: "Admin3",
                table: "Organizations",
                newName: "Admin3UserId");

            migrationBuilder.RenameColumn(
                name: "Admin2",
                table: "Organizations",
                newName: "Admin2UserId");

            migrationBuilder.RenameColumn(
                name: "Admin1",
                table: "Organizations",
                newName: "Admin1UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25704904-71a8-40da-aeac-6f6f577cc484", null, "user", "USER" },
                    { "7fa9bfac-f76f-41db-86b2-fc5feb3b8eef", null, "admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Admin1UserId",
                table: "Organizations",
                column: "Admin1UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Admin2UserId",
                table: "Organizations",
                column: "Admin2UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Admin3UserId",
                table: "Organizations",
                column: "Admin3UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OwnerUserId",
                table: "Organizations",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_Admin1UserId",
                table: "Organizations",
                column: "Admin1UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_Admin2UserId",
                table: "Organizations",
                column: "Admin2UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_Admin3UserId",
                table: "Organizations",
                column: "Admin3UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_OwnerUserId",
                table: "Organizations",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
