using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicEntitySample.Migrations
{
    public partial class RemovedTenantIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "DynamicEntityModelDefinitions");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "DynamicEntityFieldDefinitions");

            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "DynamicEntityFieldDefinitions",
                type: "int",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "DynamicEntityModelDefinitions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "DynamicEntityFieldDefinitions",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "DynamicEntityFieldDefinitions",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
