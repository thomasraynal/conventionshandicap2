using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    public partial class updateMetadataPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConventionsHandicapCertificateMetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConventionsHandicapCertificateMetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue",
                columns: new[] { "MetadataName", "MetadataValue", "CertificateDemandId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConventionsHandicapCertificateMetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConventionsHandicapCertificateMetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue",
                columns: new[] { "MetadataName", "MetadataValue" });
        }
    }
}
