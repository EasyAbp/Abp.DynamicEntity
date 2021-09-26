using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicEntitySample.Migrations
{
    public partial class AddedPermissionSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PermissionSet_Create",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionSet_Delete",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionSet_Get",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionSet_GetList",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionSet_Manage",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionSet_Update",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionSet_Create",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_Delete",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_Get",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_GetList",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_Manage",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_Update",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");
        }
    }
}
