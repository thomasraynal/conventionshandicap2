using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    public partial class updateCertificateTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MetadataValue",
                table: "ConventionsHandicapCertificateMetadataValue",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "MetadataName",
                table: "ConventionsHandicapCertificateMetadataValue",
                newName: "Code");

            migrationBuilder.AddColumn<string>(
                name: "RelativeFilePath",
                table: "ConventionsHandicapCertificateTemplate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("259df8ba-36d6-5432-8ae5-5e689c003025"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Paris\\75\\AutorisationAESHSecondDegréPrivé.docx");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("317bdf49-d0e1-5567-830b-56f589f0be4b"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Versailles\\95\\InterventionPsychologueRéférent.docx");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("375baa14-3a80-5455-8132-689867b26fea"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Versailles\\95\\AccompagnantPsychoEducatif.docx");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("6b2f85fc-d5c0-578d-9fd7-575ccb33cd82"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Paris\\75\\AutorisationAESHSecondDegréPublic.docx");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("794ac5da-8972-5a7a-8ac5-3c36171458e1"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Versailles\\92\\AccompagnementPsychoEducatif.docx");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("aa4280e4-bd35-55b1-a9e4-43ad16231a72"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Versailles\\92\\InterventionPsychologueReferent.docx");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("de45c7ad-d991-5d3b-9722-2b46095e02ed"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Paris\\75\\AutorisationAESHPremierDegréPublic.docx");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("e80d5446-44ff-5a04-9305-bdea773da507"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Paris\\75\\AutorisationAESHPremierDegréPrivé.docx");

            migrationBuilder.UpdateData(
                table: "ConventionsHandicapCertificateTemplate",
                keyColumn: "Id",
                keyValue: new Guid("e9e35c85-222f-57af-b790-79ad7761c386"),
                column: "RelativeFilePath",
                value: ".\\Features\\CertificateDemand\\Certificates\\Créteil\\93\\Convention.docx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelativeFilePath",
                table: "ConventionsHandicapCertificateTemplate");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ConventionsHandicapCertificateMetadataValue",
                newName: "MetadataValue");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "ConventionsHandicapCertificateMetadataValue",
                newName: "MetadataName");
        }
    }
}
