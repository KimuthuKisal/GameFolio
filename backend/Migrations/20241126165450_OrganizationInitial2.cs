using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class OrganizationInitial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a889c38-bc5d-48b7-a580-bfec099e3ec1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "219ce05d-6687-4fc9-b5d8-8566eef7c8a6");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Offlinetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrganizationStatus = table.Column<int>(type: "int", nullable: false),
                    JoinStatus = table.Column<int>(type: "int", nullable: false),
                    JoinQuestions = table.Column<bool>(type: "bit", nullable: false),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerUserId = table.Column<int>(type: "int", nullable: false),
                    Admin1UserId = table.Column<int>(type: "int", nullable: true),
                    Admin2UserId = table.Column<int>(type: "int", nullable: true),
                    Admin3UserId = table.Column<int>(type: "int", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationId);
                    table.ForeignKey(
                        name: "FK_Organizations_Users_Admin1UserId",
                        column: x => x.Admin1UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Organizations_Users_Admin2UserId",
                        column: x => x.Admin2UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Organizations_Users_Admin3UserId",
                        column: x => x.Admin3UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Organizations_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25704904-71a8-40da-aeac-6f6f577cc484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa9bfac-f76f-41db-86b2-fc5feb3b8eef");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a889c38-bc5d-48b7-a580-bfec099e3ec1", null, "user", "USER" },
                    { "219ce05d-6687-4fc9-b5d8-8566eef7c8a6", null, "admin", "ADMIN" }
                });
        }
    }
}
