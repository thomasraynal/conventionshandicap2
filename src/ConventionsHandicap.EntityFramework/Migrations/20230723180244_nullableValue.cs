using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    public partial class nullableValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "ConventionsHandicapFeature",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[] { new Guid("69227a83-84fe-497d-86b8-a413744da919"), null, "GenerateCertificate" });

            migrationBuilder.InsertData(
                table: "ConventionsHandicapWorkspace",
                columns: new[] { "Id", "Logo", "Name" },
                values: new object[] { new Guid("91181ddc-6ae5-4ca1-b07c-623b876eb670"), null, "Cap Handi Cap" });

            migrationBuilder.InsertData(
                table: "FeatureWorkspace",
                columns: new[] { "FeaturesId", "WorkspacesId" },
                values: new object[] { new Guid("69227a83-84fe-497d-86b8-a413744da919"), new Guid("91181ddc-6ae5-4ca1-b07c-623b876eb670") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FeatureWorkspace",
                keyColumns: new[] { "FeaturesId", "WorkspacesId" },
                keyValues: new object[] { new Guid("69227a83-84fe-497d-86b8-a413744da919"), new Guid("91181ddc-6ae5-4ca1-b07c-623b876eb670") });

            migrationBuilder.DeleteData(
                table: "ConventionsHandicapFeature",
                keyColumn: "Id",
                keyValue: new Guid("69227a83-84fe-497d-86b8-a413744da919"));

            migrationBuilder.DeleteData(
                table: "ConventionsHandicapWorkspace",
                keyColumn: "Id",
                keyValue: new Guid("91181ddc-6ae5-4ca1-b07c-623b876eb670"));

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
        }
    }
}
