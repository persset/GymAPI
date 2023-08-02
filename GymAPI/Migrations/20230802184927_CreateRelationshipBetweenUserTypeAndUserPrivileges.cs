using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymAPI.Migrations
{
    public partial class CreateRelationshipBetweenUserTypeAndUserPrivileges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPrivilegeUserType",
                columns: table => new
                {
                    PrivilegesId = table.Column<int>(type: "int", nullable: false),
                    UserTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivilegeUserType", x => new { x.PrivilegesId, x.UserTypesId });
                    table.ForeignKey(
                        name: "FK_UserPrivilegeUserType_UserPrivileges_PrivilegesId",
                        column: x => x.PrivilegesId,
                        principalTable: "UserPrivileges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrivilegeUserType_UserTypes_UserTypesId",
                        column: x => x.UserTypesId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivilegeUserType_UserTypesId",
                table: "UserPrivilegeUserType",
                column: "UserTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPrivilegeUserType");
        }
    }
}
