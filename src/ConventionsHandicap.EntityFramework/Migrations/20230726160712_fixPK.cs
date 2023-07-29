using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    public partial class fixPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConventionsHandicapCertificateMetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ConventionsHandicapCertificateMetadataValue",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConventionsHandicapCertificateMetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue",
                columns: new[] { "Code", "CertificateDemandId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ConventionsHandicapCertificateMetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "ConventionsHandicapCertificateMetadataValue",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConventionsHandicapCertificateMetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue",
                columns: new[] { "Code", "Value", "CertificateDemandId" });
        }
    }
}
