using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class TryingToFixIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 21, 15, 26, 49, 665, DateTimeKind.Local).AddTicks(8592),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 3, 21, 13, 41, 59, 62, DateTimeKind.Local).AddTicks(8298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Lists",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 21, 15, 26, 49, 665, DateTimeKind.Local).AddTicks(7998),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 3, 21, 13, 41, 59, 62, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 21, 15, 26, 49, 665, DateTimeKind.Local).AddTicks(7417),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 3, 21, 13, 41, 59, 62, DateTimeKind.Local).AddTicks(7195));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 21, 13, 41, 59, 62, DateTimeKind.Local).AddTicks(8298),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 3, 21, 15, 26, 49, 665, DateTimeKind.Local).AddTicks(8592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Lists",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 21, 13, 41, 59, 62, DateTimeKind.Local).AddTicks(7814),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 3, 21, 15, 26, 49, 665, DateTimeKind.Local).AddTicks(7998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 3, 21, 13, 41, 59, 62, DateTimeKind.Local).AddTicks(7195),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 3, 21, 15, 26, 49, 665, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RolesId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RolesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_RoleUser_AspNetRoles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UsersId",
                table: "RoleUser",
                column: "UsersId");
        }
    }
}
