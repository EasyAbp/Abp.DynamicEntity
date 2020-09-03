using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSample.Migrations
{
    public partial class AddIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExtraProperties",
                table: "DynamicDynamicEntities",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicModelDefinitions_Name",
                table: "DynamicModelDefinitions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFieldDefinitions_Name",
                table: "DynamicFieldDefinitions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicDynamicEntities_ExtraProperties",
                table: "DynamicDynamicEntities",
                column: "ExtraProperties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DynamicModelDefinitions_Name",
                table: "DynamicModelDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_DynamicFieldDefinitions_Name",
                table: "DynamicFieldDefinitions");

            migrationBuilder.DropIndex(
                name: "IX_DynamicDynamicEntities_ExtraProperties",
                table: "DynamicDynamicEntities");

            migrationBuilder.AlterColumn<string>(
                name: "ExtraProperties",
                table: "DynamicDynamicEntities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
