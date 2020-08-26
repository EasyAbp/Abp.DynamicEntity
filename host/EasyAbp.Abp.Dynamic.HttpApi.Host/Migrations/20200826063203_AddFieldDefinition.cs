using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyAbp.Abp.Dynamic.Migrations
{
    public partial class AddFieldDefinition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DynamicFieldDefinitions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "DynamicFieldDefinitions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "DynamicFieldDefinitions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DynamicFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "DynamicFieldDefinitions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DynamicFieldDefinitions");
        }
    }
}
