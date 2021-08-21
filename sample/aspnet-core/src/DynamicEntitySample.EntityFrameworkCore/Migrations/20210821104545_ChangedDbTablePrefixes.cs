using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicEntitySample.Migrations
{
    public partial class ChangedDbTablePrefixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DynamicEntityDynamicEntities_DynamicEntityModelDefinitions_ModelDefinitionId",
                table: "DynamicEntityDynamicEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_DynamicEntityModelFields_DynamicEntityFieldDefinitions_FieldDefinitionId",
                table: "DynamicEntityModelFields");

            migrationBuilder.DropForeignKey(
                name: "FK_DynamicEntityModelFields_DynamicEntityModelDefinitions_ModelDefinitionId",
                table: "DynamicEntityModelFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DynamicEntityModelFields",
                table: "DynamicEntityModelFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DynamicEntityModelDefinitions",
                table: "DynamicEntityModelDefinitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DynamicEntityFieldDefinitions",
                table: "DynamicEntityFieldDefinitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DynamicEntityDynamicEntities",
                table: "DynamicEntityDynamicEntities");

            migrationBuilder.RenameTable(
                name: "DynamicEntityModelFields",
                newName: "EasyAbpAbpDynamicEntityModelFields");

            migrationBuilder.RenameTable(
                name: "DynamicEntityModelDefinitions",
                newName: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.RenameTable(
                name: "DynamicEntityFieldDefinitions",
                newName: "EasyAbpAbpDynamicEntityFieldDefinitions");

            migrationBuilder.RenameTable(
                name: "DynamicEntityDynamicEntities",
                newName: "EasyAbpAbpDynamicEntityDynamicEntities");

            migrationBuilder.RenameIndex(
                name: "IX_DynamicEntityModelFields_ModelDefinitionId",
                table: "EasyAbpAbpDynamicEntityModelFields",
                newName: "IX_EasyAbpAbpDynamicEntityModelFields_ModelDefinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_DynamicEntityModelDefinitions_Name",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                newName: "IX_EasyAbpAbpDynamicEntityModelDefinitions_Name");

            migrationBuilder.RenameIndex(
                name: "IX_DynamicEntityFieldDefinitions_Name",
                table: "EasyAbpAbpDynamicEntityFieldDefinitions",
                newName: "IX_EasyAbpAbpDynamicEntityFieldDefinitions_Name");

            migrationBuilder.RenameIndex(
                name: "IX_DynamicEntityDynamicEntities_ModelDefinitionId",
                table: "EasyAbpAbpDynamicEntityDynamicEntities",
                newName: "IX_EasyAbpAbpDynamicEntityDynamicEntities_ModelDefinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_DynamicEntityDynamicEntities_ExtraProperties",
                table: "EasyAbpAbpDynamicEntityDynamicEntities",
                newName: "IX_EasyAbpAbpDynamicEntityDynamicEntities_ExtraProperties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpAbpDynamicEntityModelFields",
                table: "EasyAbpAbpDynamicEntityModelFields",
                columns: new[] { "FieldDefinitionId", "ModelDefinitionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpAbpDynamicEntityModelDefinitions",
                table: "EasyAbpAbpDynamicEntityModelDefinitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpAbpDynamicEntityFieldDefinitions",
                table: "EasyAbpAbpDynamicEntityFieldDefinitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EasyAbpAbpDynamicEntityDynamicEntities",
                table: "EasyAbpAbpDynamicEntityDynamicEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EasyAbpAbpDynamicEntityDynamicEntities_EasyAbpAbpDynamicEntityModelDefinitions_ModelDefinitionId",
                table: "EasyAbpAbpDynamicEntityDynamicEntities",
                column: "ModelDefinitionId",
                principalTable: "EasyAbpAbpDynamicEntityModelDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_EasyAbpAbpDynamicEntityModelFields_EasyAbpAbpDynamicEntityFieldDefinitions_FieldDefinitionId",
                table: "EasyAbpAbpDynamicEntityModelFields",
                column: "FieldDefinitionId",
                principalTable: "EasyAbpAbpDynamicEntityFieldDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EasyAbpAbpDynamicEntityModelFields_EasyAbpAbpDynamicEntityModelDefinitions_ModelDefinitionId",
                table: "EasyAbpAbpDynamicEntityModelFields",
                column: "ModelDefinitionId",
                principalTable: "EasyAbpAbpDynamicEntityModelDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasyAbpAbpDynamicEntityDynamicEntities_EasyAbpAbpDynamicEntityModelDefinitions_ModelDefinitionId",
                table: "EasyAbpAbpDynamicEntityDynamicEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_EasyAbpAbpDynamicEntityModelFields_EasyAbpAbpDynamicEntityFieldDefinitions_FieldDefinitionId",
                table: "EasyAbpAbpDynamicEntityModelFields");

            migrationBuilder.DropForeignKey(
                name: "FK_EasyAbpAbpDynamicEntityModelFields_EasyAbpAbpDynamicEntityModelDefinitions_ModelDefinitionId",
                table: "EasyAbpAbpDynamicEntityModelFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpAbpDynamicEntityModelFields",
                table: "EasyAbpAbpDynamicEntityModelFields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpAbpDynamicEntityModelDefinitions",
                table: "EasyAbpAbpDynamicEntityModelDefinitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpAbpDynamicEntityFieldDefinitions",
                table: "EasyAbpAbpDynamicEntityFieldDefinitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EasyAbpAbpDynamicEntityDynamicEntities",
                table: "EasyAbpAbpDynamicEntityDynamicEntities");

            migrationBuilder.RenameTable(
                name: "EasyAbpAbpDynamicEntityModelFields",
                newName: "DynamicEntityModelFields");

            migrationBuilder.RenameTable(
                name: "EasyAbpAbpDynamicEntityModelDefinitions",
                newName: "DynamicEntityModelDefinitions");

            migrationBuilder.RenameTable(
                name: "EasyAbpAbpDynamicEntityFieldDefinitions",
                newName: "DynamicEntityFieldDefinitions");

            migrationBuilder.RenameTable(
                name: "EasyAbpAbpDynamicEntityDynamicEntities",
                newName: "DynamicEntityDynamicEntities");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpAbpDynamicEntityModelFields_ModelDefinitionId",
                table: "DynamicEntityModelFields",
                newName: "IX_DynamicEntityModelFields_ModelDefinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpAbpDynamicEntityModelDefinitions_Name",
                table: "DynamicEntityModelDefinitions",
                newName: "IX_DynamicEntityModelDefinitions_Name");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpAbpDynamicEntityFieldDefinitions_Name",
                table: "DynamicEntityFieldDefinitions",
                newName: "IX_DynamicEntityFieldDefinitions_Name");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpAbpDynamicEntityDynamicEntities_ModelDefinitionId",
                table: "DynamicEntityDynamicEntities",
                newName: "IX_DynamicEntityDynamicEntities_ModelDefinitionId");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpAbpDynamicEntityDynamicEntities_ExtraProperties",
                table: "DynamicEntityDynamicEntities",
                newName: "IX_DynamicEntityDynamicEntities_ExtraProperties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DynamicEntityModelFields",
                table: "DynamicEntityModelFields",
                columns: new[] { "FieldDefinitionId", "ModelDefinitionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DynamicEntityModelDefinitions",
                table: "DynamicEntityModelDefinitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DynamicEntityFieldDefinitions",
                table: "DynamicEntityFieldDefinitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DynamicEntityDynamicEntities",
                table: "DynamicEntityDynamicEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicEntityDynamicEntities_DynamicEntityModelDefinitions_ModelDefinitionId",
                table: "DynamicEntityDynamicEntities",
                column: "ModelDefinitionId",
                principalTable: "DynamicEntityModelDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicEntityModelFields_DynamicEntityFieldDefinitions_FieldDefinitionId",
                table: "DynamicEntityModelFields",
                column: "FieldDefinitionId",
                principalTable: "DynamicEntityFieldDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DynamicEntityModelFields_DynamicEntityModelDefinitions_ModelDefinitionId",
                table: "DynamicEntityModelFields",
                column: "ModelDefinitionId",
                principalTable: "DynamicEntityModelDefinitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
