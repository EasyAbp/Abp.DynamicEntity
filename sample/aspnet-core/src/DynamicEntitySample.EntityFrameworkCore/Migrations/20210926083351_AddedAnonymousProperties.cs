using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicEntitySample.Migrations
{
    public partial class AddedAnonymousProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PermissionSet_AnonymousCreate",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PermissionSet_AnonymousDelete",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PermissionSet_AnonymousGet",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PermissionSet_AnonymousGetList",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PermissionSet_AnonymousUpdate",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PermissionSet_AnonymousCreate",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_AnonymousDelete",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_AnonymousGet",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_AnonymousGetList",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "PermissionSet_AnonymousUpdate",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");
        }
    }
}
