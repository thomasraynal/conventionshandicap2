using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    public partial class fixSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateDemand_ConventionsHandicapCertificateDemandId",
                table: "CertificateTemplateCertificateDemand");

            migrationBuilder.DropForeignKey(
                name: "FK_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateTemplate_ConventionsHandicapCertificateTemplateId",
                table: "CertificateTemplateCertificateDemand");

            migrationBuilder.DropIndex(
                name: "IX_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateDemandId",
                table: "CertificateTemplateCertificateDemand");

            migrationBuilder.DropIndex(
                name: "IX_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateTemplateId",
                table: "CertificateTemplateCertificateDemand");

            migrationBuilder.DropColumn(
                name: "ConventionsHandicapCertificateDemandId",
                table: "CertificateTemplateCertificateDemand");

            migrationBuilder.DropColumn(
                name: "ConventionsHandicapCertificateTemplateId",
                table: "CertificateTemplateCertificateDemand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConventionsHandicapCertificateDemandId",
                table: "CertificateTemplateCertificateDemand",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ConventionsHandicapCertificateTemplateId",
                table: "CertificateTemplateCertificateDemand",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateDemandId",
                table: "CertificateTemplateCertificateDemand",
                column: "ConventionsHandicapCertificateDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateTemplateId",
                table: "CertificateTemplateCertificateDemand",
                column: "ConventionsHandicapCertificateTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateDemand_ConventionsHandicapCertificateDemandId",
                table: "CertificateTemplateCertificateDemand",
                column: "ConventionsHandicapCertificateDemandId",
                principalTable: "ConventionsHandicapCertificateDemand",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateTemplate_ConventionsHandicapCertificateTemplateId",
                table: "CertificateTemplateCertificateDemand",
                column: "ConventionsHandicapCertificateTemplateId",
                principalTable: "ConventionsHandicapCertificateTemplate",
                principalColumn: "Id");
        }
    }
}
