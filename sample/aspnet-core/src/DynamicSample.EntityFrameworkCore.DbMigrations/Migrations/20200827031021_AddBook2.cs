using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSample.Migrations
{
    public partial class AddBook2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ModelDefinitionId",
                table: "AppBooks",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppBooks_ModelDefinitionId",
                table: "AppBooks",
                column: "ModelDefinitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppBooks_DynamicModelDefinitions_ModelDefinitionId",
                table: "AppBooks",
                column: "ModelDefinitionId",
                principalTable: "DynamicModelDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppBooks_DynamicModelDefinitions_ModelDefinitionId",
                table: "AppBooks");

            migrationBuilder.DropIndex(
                name: "IX_AppBooks_ModelDefinitionId",
                table: "AppBooks");

            migrationBuilder.DropColumn(
                name: "ModelDefinitionId",
                table: "AppBooks");
        }
    }
}
