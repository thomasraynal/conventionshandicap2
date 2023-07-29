using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    public partial class seedWorkspace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConventionsHandicapFeatureConventionsHandicapWorkspace_ConventionsHandicapFeature_FeaturesId",
                table: "ConventionsHandicapFeatureConventionsHandicapWorkspace");

            migrationBuilder.DropForeignKey(
                name: "FK_ConventionsHandicapFeatureConventionsHandicapWorkspace_ConventionsHandicapWorkspace_WorkspacesId",
                table: "ConventionsHandicapFeatureConventionsHandicapWorkspace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConventionsHandicapFeatureConventionsHandicapWorkspace",
                table: "ConventionsHandicapFeatureConventionsHandicapWorkspace");

            migrationBuilder.RenameTable(
                name: "ConventionsHandicapFeatureConventionsHandicapWorkspace",
                newName: "FeatureWorkspace");

            migrationBuilder.RenameIndex(
                name: "IX_ConventionsHandicapFeatureConventionsHandicapWorkspace_WorkspacesId",
                table: "FeatureWorkspace",
                newName: "IX_FeatureWorkspace_WorkspacesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeatureWorkspace",
                table: "FeatureWorkspace",
                columns: new[] { "FeaturesId", "WorkspacesId" });

            migrationBuilder.InsertData(
                table: "ConventionsHandicapFeature",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { new Guid("5e8e67e6-c218-45f3-b3ef-db2bfdab3975"), null, "GenerateCertificate" });

            migrationBuilder.InsertData(
                table: "ConventionsHandicapWorkspace",
                columns: new[] { "Id", "Logo", "Name" },
                values: new object[] { new Guid("063412b6-69c8-41c0-ae73-fd1cc524d657"), null, "Cap Handi Cap" });

            migrationBuilder.InsertData(
                table: "FeatureWorkspace",
                columns: new[] { "FeaturesId", "WorkspacesId" },
                values: new object[] { new Guid("5e8e67e6-c218-45f3-b3ef-db2bfdab3975"), new Guid("063412b6-69c8-41c0-ae73-fd1cc524d657") });

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureWorkspace_ConventionsHandicapFeature_FeaturesId",
                table: "FeatureWorkspace",
                column: "FeaturesId",
                principalTable: "ConventionsHandicapFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureWorkspace_ConventionsHandicapWorkspace_WorkspacesId",
                table: "FeatureWorkspace",
                column: "WorkspacesId",
                principalTable: "ConventionsHandicapWorkspace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureWorkspace_ConventionsHandicapFeature_FeaturesId",
                table: "FeatureWorkspace");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureWorkspace_ConventionsHandicapWorkspace_WorkspacesId",
                table: "FeatureWorkspace");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeatureWorkspace",
                table: "FeatureWorkspace");

            migrationBuilder.DeleteData(
                table: "FeatureWorkspace",
                keyColumns: new[] { "FeaturesId", "WorkspacesId" },
                keyValues: new object[] { new Guid("5e8e67e6-c218-45f3-b3ef-db2bfdab3975"), new Guid("063412b6-69c8-41c0-ae73-fd1cc524d657") });

            migrationBuilder.DeleteData(
                table: "ConventionsHandicapFeature",
                keyColumn: "Id",
                keyValue: new Guid("5e8e67e6-c218-45f3-b3ef-db2bfdab3975"));

            migrationBuilder.DeleteData(
                table: "ConventionsHandicapWorkspace",
                keyColumn: "Id",
                keyValue: new Guid("063412b6-69c8-41c0-ae73-fd1cc524d657"));

            migrationBuilder.RenameTable(
                name: "FeatureWorkspace",
                newName: "ConventionsHandicapFeatureConventionsHandicapWorkspace");

            migrationBuilder.RenameIndex(
                name: "IX_FeatureWorkspace_WorkspacesId",
                table: "ConventionsHandicapFeatureConventionsHandicapWorkspace",
                newName: "IX_ConventionsHandicapFeatureConventionsHandicapWorkspace_WorkspacesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConventionsHandicapFeatureConventionsHandicapWorkspace",
                table: "ConventionsHandicapFeatureConventionsHandicapWorkspace",
                columns: new[] { "FeaturesId", "WorkspacesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConventionsHandicapFeatureConventionsHandicapWorkspace_ConventionsHandicapFeature_FeaturesId",
                table: "ConventionsHandicapFeatureConventionsHandicapWorkspace",
                column: "FeaturesId",
                principalTable: "ConventionsHandicapFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConventionsHandicapFeatureConventionsHandicapWorkspace_ConventionsHandicapWorkspace_WorkspacesId",
                table: "ConventionsHandicapFeatureConventionsHandicapWorkspace",
                column: "WorkspacesId",
                principalTable: "ConventionsHandicapWorkspace",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
