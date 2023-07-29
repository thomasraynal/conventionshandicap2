﻿// <auto-generated />
using System;
using ConventionsHandicap.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConventionsHandicap.EntityFramework.Migrations
{
    [DbContext(typeof(ConventionHandicapDbContext))]
    [Migration("20230723180244_nullableValue")]
    partial class nullableValue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CertificateTemplateCertificateDemand", b =>
                {
                    b.Property<Guid>("CertificateDemandsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CertificateTemplatesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CertificateDemandsId", "CertificateTemplatesId");

                    b.HasIndex("CertificateTemplatesId");

                    b.ToTable("CertificateTemplateCertificateDemand");
                });

            modelBuilder.Entity("ConventionsHandicap.EntityFramework.ConventionsHandicapIdentityRole", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("WorkspaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Name");

                    b.ToTable("ConventionsHandicapIdentityRole", (string)null);
                });

            modelBuilder.Entity("ConventionsHandicap.EntityFramework.ConventionsHandicapUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserTemporaryPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConventionsHandicapUser", (string)null);
                });

            modelBuilder.Entity("ConventionsHandicap.EntityFramework.ConventionsHandicapWorkspace", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConventionsHandicapWorkspace", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("91181ddc-6ae5-4ca1-b07c-623b876eb670"),
                            Name = "Cap Handi Cap"
                        });
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Academy", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Academy", (string)null);

                    b.HasData(
                        new
                        {
                            Name = "Versailles"
                        },
                        new
                        {
                            Name = "Paris"
                        },
                        new
                        {
                            Name = "Créteil"
                        });
                });

            modelBuilder.Entity("ConventionsHandicap.Model.ConventionsHandicapFeature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ConventionsHandicapFeature", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("69227a83-84fe-497d-86b8-a413744da919"),
                            Name = "GenerateCertificate"
                        });
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Department", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AcademyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.HasIndex("AcademyName");

                    b.ToTable("Department", (string)null);

                    b.HasData(
                        new
                        {
                            Name = "92",
                            AcademyName = "Versailles"
                        },
                        new
                        {
                            Name = "94",
                            AcademyName = "Versailles"
                        },
                        new
                        {
                            Name = "95",
                            AcademyName = "Versailles"
                        },
                        new
                        {
                            Name = "93",
                            AcademyName = "Créteil"
                        },
                        new
                        {
                            Name = "75",
                            AcademyName = "Paris"
                        });
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateDemand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CertificateDemandStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ChildDateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("ChildFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChildLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkspaceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AcademyName");

                    b.HasIndex("DepartmentName");

                    b.HasIndex("UserId");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("ConventionsHandicapCertificateDemand", (string)null);
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateMetadataValue", b =>
                {
                    b.Property<string>("MetadataName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MetadataValue")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("CertificateDemandId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MetadataName", "MetadataValue");

                    b.HasIndex("CertificateDemandId");

                    b.ToTable("ConventionsHandicapCertificateMetadataValue", (string)null);
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TemplateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcademyName");

                    b.HasIndex("DepartmentName");

                    b.ToTable("ConventionsHandicapCertificateTemplate", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9e35c85-222f-57af-b790-79ad7761c386"),
                            AcademyName = "Créteil",
                            DepartmentName = "93",
                            TemplateName = "Convention.docx"
                        },
                        new
                        {
                            Id = new Guid("e80d5446-44ff-5a04-9305-bdea773da507"),
                            AcademyName = "Paris",
                            DepartmentName = "75",
                            TemplateName = "AutorisationAESHPremierDegréPrivé.docx"
                        },
                        new
                        {
                            Id = new Guid("de45c7ad-d991-5d3b-9722-2b46095e02ed"),
                            AcademyName = "Paris",
                            DepartmentName = "75",
                            TemplateName = "AutorisationAESHPremierDegréPublic.docx"
                        },
                        new
                        {
                            Id = new Guid("259df8ba-36d6-5432-8ae5-5e689c003025"),
                            AcademyName = "Paris",
                            DepartmentName = "75",
                            TemplateName = "AutorisationAESHSecondDegréPrivé.docx"
                        },
                        new
                        {
                            Id = new Guid("6b2f85fc-d5c0-578d-9fd7-575ccb33cd82"),
                            AcademyName = "Paris",
                            DepartmentName = "75",
                            TemplateName = "AutorisationAESHSecondDegréPublic.docx"
                        },
                        new
                        {
                            Id = new Guid("794ac5da-8972-5a7a-8ac5-3c36171458e1"),
                            AcademyName = "Versailles",
                            DepartmentName = "92",
                            TemplateName = "AccompagnementPsychoEducatif.docx"
                        },
                        new
                        {
                            Id = new Guid("aa4280e4-bd35-55b1-a9e4-43ad16231a72"),
                            AcademyName = "Versailles",
                            DepartmentName = "92",
                            TemplateName = "InterventionPsychologueReferent.docx"
                        },
                        new
                        {
                            Id = new Guid("375baa14-3a80-5455-8132-689867b26fea"),
                            AcademyName = "Versailles",
                            DepartmentName = "95",
                            TemplateName = "AccompagnantPsychoEducatif.docx"
                        },
                        new
                        {
                            Id = new Guid("317bdf49-d0e1-5567-830b-56f589f0be4b"),
                            AcademyName = "Versailles",
                            DepartmentName = "95",
                            TemplateName = "InterventionPsychologueRéférent.docx"
                        });
                });

            modelBuilder.Entity("ConventionsHandicapFeatureConventionsHandicapWorkspace", b =>
                {
                    b.Property<Guid>("FeaturesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WorkspacesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FeaturesId", "WorkspacesId");

                    b.HasIndex("WorkspacesId");

                    b.ToTable("FeatureWorkspace", (string)null);

                    b.HasData(
                        new
                        {
                            FeaturesId = new Guid("69227a83-84fe-497d-86b8-a413744da919"),
                            WorkspacesId = new Guid("91181ddc-6ae5-4ca1-b07c-623b876eb670")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("IdentityUserRole", (string)null);
                });

            modelBuilder.Entity("CertificateTemplateCertificateDemand", b =>
                {
                    b.HasOne("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateDemand", null)
                        .WithMany()
                        .HasForeignKey("CertificateDemandsId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateTemplate", null)
                        .WithMany()
                        .HasForeignKey("CertificateTemplatesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Department", b =>
                {
                    b.HasOne("ConventionsHandicap.Model.Academy", "Academy")
                        .WithMany("Departments")
                        .HasForeignKey("AcademyName")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Academy");
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateDemand", b =>
                {
                    b.HasOne("ConventionsHandicap.Model.Academy", "Academy")
                        .WithMany()
                        .HasForeignKey("AcademyName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConventionsHandicap.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConventionsHandicap.EntityFramework.ConventionsHandicapUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConventionsHandicap.EntityFramework.ConventionsHandicapWorkspace", "Workspace")
                        .WithMany()
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Academy");

                    b.Navigation("Department");

                    b.Navigation("User");

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateMetadataValue", b =>
                {
                    b.HasOne("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateDemand", "CertificateDemand")
                        .WithMany("Properties")
                        .HasForeignKey("CertificateDemandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CertificateDemand");
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateTemplate", b =>
                {
                    b.HasOne("ConventionsHandicap.Model.Academy", "Academy")
                        .WithMany()
                        .HasForeignKey("AcademyName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConventionsHandicap.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Academy");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ConventionsHandicapFeatureConventionsHandicapWorkspace", b =>
                {
                    b.HasOne("ConventionsHandicap.Model.ConventionsHandicapFeature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConventionsHandicap.EntityFramework.ConventionsHandicapWorkspace", null)
                        .WithMany()
                        .HasForeignKey("WorkspacesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Academy", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("ConventionsHandicap.Model.Features.CertificateDemand.ConventionsHandicapCertificateDemand", b =>
                {
                    b.Navigation("Properties");
                });
#pragma warning restore 612, 618
        }
    }
}
