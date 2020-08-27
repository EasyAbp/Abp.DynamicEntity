using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSample.Migrations
{
    public partial class AddStaticFieldsToComputer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComputerType",
                table: "AppComputers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "AppComputers",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerType",
                table: "AppComputers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "AppComputers");
        }
    }
}
