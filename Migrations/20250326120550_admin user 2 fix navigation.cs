using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Studentregistreringsprogram_Databas.Migrations
{
    /// <inheritdoc />
    public partial class adminuser2fixnavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemUsers_Roles_UserRoleIdRoleId",
                table: "SystemUsers");

            migrationBuilder.RenameColumn(
                name: "UserRoleIdRoleId",
                table: "SystemUsers",
                newName: "UserRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_SystemUsers_UserRoleIdRoleId",
                table: "SystemUsers",
                newName: "IX_SystemUsers_UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUsers_Roles_UserRoleId",
                table: "SystemUsers",
                column: "UserRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemUsers_Roles_UserRoleId",
                table: "SystemUsers");

            migrationBuilder.RenameColumn(
                name: "UserRoleId",
                table: "SystemUsers",
                newName: "UserRoleIdRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_SystemUsers_UserRoleId",
                table: "SystemUsers",
                newName: "IX_SystemUsers_UserRoleIdRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUsers_Roles_UserRoleIdRoleId",
                table: "SystemUsers",
                column: "UserRoleIdRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
