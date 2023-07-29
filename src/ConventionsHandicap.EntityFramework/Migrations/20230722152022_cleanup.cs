using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    public partial class cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academy",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academy", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "ConventionsHandicapFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionsHandicapFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConventionsHandicapIdentityRole",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkspaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionsHandicapIdentityRole", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "ConventionsHandicapUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserTemporaryPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionsHandicapUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConventionsHandicapWorkspace",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionsHandicapWorkspace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AcademyName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Department_Academy_AcademyName",
                        column: x => x.AcademyName,
                        principalTable: "Academy",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConventionsHandicapFeatureConventionsHandicapWorkspace",
                columns: table => new
                {
                    FeaturesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkspacesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionsHandicapFeatureConventionsHandicapWorkspace", x => new { x.FeaturesId, x.WorkspacesId });
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapFeatureConventionsHandicapWorkspace_ConventionsHandicapFeature_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "ConventionsHandicapFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapFeatureConventionsHandicapWorkspace_ConventionsHandicapWorkspace_WorkspacesId",
                        column: x => x.WorkspacesId,
                        principalTable: "ConventionsHandicapWorkspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConventionsHandicapCertificateDemand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChildFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChildDateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkspaceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificateDemandStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionsHandicapCertificateDemand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapCertificateDemand_Academy_AcademyName",
                        column: x => x.AcademyName,
                        principalTable: "Academy",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapCertificateDemand_ConventionsHandicapUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ConventionsHandicapUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapCertificateDemand_ConventionsHandicapWorkspace_WorkspaceId",
                        column: x => x.WorkspaceId,
                        principalTable: "ConventionsHandicapWorkspace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapCertificateDemand_Department_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Department",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConventionsHandicapCertificateTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionsHandicapCertificateTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapCertificateTemplate_Academy_AcademyName",
                        column: x => x.AcademyName,
                        principalTable: "Academy",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapCertificateTemplate_Department_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Department",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConventionsHandicapCertificateMetadataValue",
                columns: table => new
                {
                    MetadataName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MetadataValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CertificateDemandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionsHandicapCertificateMetadataValue", x => new { x.MetadataName, x.MetadataValue });
                    table.ForeignKey(
                        name: "FK_ConventionsHandicapCertificateMetadataValue_ConventionsHandicapCertificateDemand_CertificateDemandId",
                        column: x => x.CertificateDemandId,
                        principalTable: "ConventionsHandicapCertificateDemand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CertificateTemplateCertificateDemand",
                columns: table => new
                {
                    CertificateDemandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificateTemplatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConventionsHandicapCertificateDemandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConventionsHandicapCertificateTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificateTemplateCertificateDemand", x => new { x.CertificateDemandsId, x.CertificateTemplatesId });
                    table.ForeignKey(
                        name: "FK_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateDemand_CertificateDemandsId",
                        column: x => x.CertificateDemandsId,
                        principalTable: "ConventionsHandicapCertificateDemand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateDemand_ConventionsHandicapCertificateDemandId",
                        column: x => x.ConventionsHandicapCertificateDemandId,
                        principalTable: "ConventionsHandicapCertificateDemand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateTemplate_CertificateTemplatesId",
                        column: x => x.CertificateTemplatesId,
                        principalTable: "ConventionsHandicapCertificateTemplate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateTemplate_ConventionsHandicapCertificateTemplateId",
                        column: x => x.ConventionsHandicapCertificateTemplateId,
                        principalTable: "ConventionsHandicapCertificateTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Academy",
                column: "Name",
                value: "Créteil");

            migrationBuilder.InsertData(
                table: "Academy",
                column: "Name",
                value: "Paris");

            migrationBuilder.InsertData(
                table: "Academy",
                column: "Name",
                value: "Versailles");

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Name", "AcademyName" },
                values: new object[,]
                {
                    { "75", "Paris" },
                    { "92", "Versailles" },
                    { "93", "Créteil" },
                    { "94", "Versailles" },
                    { "95", "Versailles" }
                });

            migrationBuilder.InsertData(
                table: "ConventionsHandicapCertificateTemplate",
                columns: new[] { "Id", "AcademyName", "DepartmentName", "TemplateName" },
                values: new object[,]
                {
                    { new Guid("259df8ba-36d6-5432-8ae5-5e689c003025"), "Paris", "75", "AutorisationAESHSecondDegréPrivé.docx" },
                    { new Guid("317bdf49-d0e1-5567-830b-56f589f0be4b"), "Versailles", "95", "InterventionPsychologueRéférent.docx" },
                    { new Guid("375baa14-3a80-5455-8132-689867b26fea"), "Versailles", "95", "AccompagnantPsychoEducatif.docx" },
                    { new Guid("6b2f85fc-d5c0-578d-9fd7-575ccb33cd82"), "Paris", "75", "AutorisationAESHSecondDegréPublic.docx" },
                    { new Guid("794ac5da-8972-5a7a-8ac5-3c36171458e1"), "Versailles", "92", "AccompagnementPsychoEducatif.docx" },
                    { new Guid("aa4280e4-bd35-55b1-a9e4-43ad16231a72"), "Versailles", "92", "InterventionPsychologueReferent.docx" },
                    { new Guid("de45c7ad-d991-5d3b-9722-2b46095e02ed"), "Paris", "75", "AutorisationAESHPremierDegréPublic.docx" },
                    { new Guid("e80d5446-44ff-5a04-9305-bdea773da507"), "Paris", "75", "AutorisationAESHPremierDegréPrivé.docx" },
                    { new Guid("e9e35c85-222f-57af-b790-79ad7761c386"), "Créteil", "93", "Convention.docx" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTemplateCertificateDemand_CertificateTemplatesId",
                table: "CertificateTemplateCertificateDemand",
                column: "CertificateTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateDemandId",
                table: "CertificateTemplateCertificateDemand",
                column: "ConventionsHandicapCertificateDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificateTemplateCertificateDemand_ConventionsHandicapCertificateTemplateId",
                table: "CertificateTemplateCertificateDemand",
                column: "ConventionsHandicapCertificateTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionsHandicapCertificateDemand_AcademyName",
                table: "ConventionsHandicapCertificateDemand",
                column: "AcademyName");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionsHandicapCertificateDemand_DepartmentName",
                table: "ConventionsHandicapCertificateDemand",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionsHandicapCertificateDemand_UserId",
                table: "ConventionsHandicapCertificateDemand",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionsHandicapCertificateDemand_WorkspaceId",
                table: "ConventionsHandicapCertificateDemand",
                column: "WorkspaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionsHandicapCertificateMetadataValue_CertificateDemandId",
                table: "ConventionsHandicapCertificateMetadataValue",
                column: "CertificateDemandId");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionsHandicapCertificateTemplate_AcademyName",
                table: "ConventionsHandicapCertificateTemplate",
                column: "AcademyName");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionsHandicapCertificateTemplate_DepartmentName",
                table: "ConventionsHandicapCertificateTemplate",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionsHandicapFeatureConventionsHandicapWorkspace_WorkspacesId",
                table: "ConventionsHandicapFeatureConventionsHandicapWorkspace",
                column: "WorkspacesId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_AcademyName",
                table: "Department",
                column: "AcademyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificateTemplateCertificateDemand");

            migrationBuilder.DropTable(
                name: "ConventionsHandicapCertificateMetadataValue");

            migrationBuilder.DropTable(
                name: "ConventionsHandicapFeatureConventionsHandicapWorkspace");

            migrationBuilder.DropTable(
                name: "ConventionsHandicapIdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityUserRole");

            migrationBuilder.DropTable(
                name: "ConventionsHandicapCertificateTemplate");

            migrationBuilder.DropTable(
                name: "ConventionsHandicapCertificateDemand");

            migrationBuilder.DropTable(
                name: "ConventionsHandicapFeature");

            migrationBuilder.DropTable(
                name: "ConventionsHandicapUser");

            migrationBuilder.DropTable(
                name: "ConventionsHandicapWorkspace");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Academy");
        }
    }
}
