﻿// <auto-generated />
using System;
using AcessaCity.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcessaCity.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200528005859_FirstAppMigration")]
    partial class FirstAppMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AcessaCity.Business.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("IBGECode")
                        .HasColumnType("int");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<Guid>("StateId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7ae590f1-c6a4-4bb3-91bf-1e82ea45bb4b"),
                            IBGECode = 3509502,
                            Latitude = -22.8920565m,
                            Longitude = -47.2079794m,
                            Name = "Campinas",
                            StateId = new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661")
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.CityHall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Number")
                        .HasColumnType("varchar(45)");

                    b.Property<bool>("Verified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("ZIPCode")
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CityHalls");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.InteractionHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("NewReportStatusId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("oldReportStatusId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("NewReportStatusId");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.HasIndex("oldReportStatusId");

                    b.ToTable("InteractionHistories");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.InteractionHistoryCommentary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Commentary")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("InteractionHistoryCommentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("InteractionHistoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("InteractionHistoryCommentId");

                    b.HasIndex("InteractionHistoryId");

                    b.HasIndex("UserId");

                    b.ToTable("InteractionHistoryCommentaries");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Accuracy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10,8)")
                        .HasDefaultValue(0m);

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CityId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CoordinatorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("Latitude")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10,8)")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("Longitude")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10,8)")
                        .HasDefaultValue(0m);

                    b.Property<string>("Neighborhood")
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<Guid>("ReportStatusId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Street")
                        .HasColumnType("varchar(250) CHARACTER SET utf8mb4")
                        .HasMaxLength(250);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<Guid>("UrgencyLevelId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.HasIndex("CoordinatorId");

                    b.HasIndex("ReportStatusId");

                    b.HasIndex("UrgencyLevelId");

                    b.HasIndex("UserId");

                    b.ToTable("Report");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportAttachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("MediaType")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<Guid>("ReportId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportAttachments");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportClassification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("ReportClassifications");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportCommentary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Commentary")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("ReportComments");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportInProgress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DoneDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("InteractionHistoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("OwnerUserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ReportId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("InteractionHistoryId");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("ReportId");

                    b.HasIndex("UserId");

                    b.ToTable("ReporstInProgress");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Approved")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Denied")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<bool>("InProgress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<bool>("Review")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("ReportStatus");

                    b.HasData(
                        new
                        {
                            Id = new Guid("96afa0df-8ad9-4a44-a726-70582b7bd010"),
                            Approved = true,
                            Denied = false,
                            Description = "Aprovado",
                            InProgress = false,
                            Review = false
                        },
                        new
                        {
                            Id = new Guid("52ccae2e-af86-4fcc-82ea-9234088dbedf"),
                            Approved = false,
                            Denied = true,
                            Description = "Negado",
                            InProgress = false,
                            Review = false
                        },
                        new
                        {
                            Id = new Guid("c37d9588-1875-44dd-8cf1-6781de7533c3"),
                            Approved = false,
                            Denied = false,
                            Description = "Em progresso",
                            InProgress = true,
                            Review = false
                        },
                        new
                        {
                            Id = new Guid("48cf5f0f-40c9-4a79-9627-6fd22018f72c"),
                            Approved = false,
                            Denied = false,
                            Description = "Em análise",
                            InProgress = false,
                            Review = true
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a134413f-fed2-411d-a157-215a0a5eff03"),
                            Name = "user"
                        },
                        new
                        {
                            Id = new Guid("859eca17-0122-489b-8528-9e873ac56f74"),
                            Name = "moderator"
                        },
                        new
                        {
                            Id = new Guid("f5e0afe9-f2e1-473c-99bc-01aa12c196ce"),
                            Name = "coordinator"
                        },
                        new
                        {
                            Id = new Guid("a22497ac-2331-4172-af66-b40fa16e637c"),
                            Name = "admin"
                        },
                        new
                        {
                            Id = new Guid("9620e0d0-ab29-4f23-a409-9f6e05058f60"),
                            Name = "city_hall"
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.State", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("UFCode")
                        .IsRequired()
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.HasKey("Id");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661"),
                            Name = "São Paulo",
                            UFCode = "SP"
                        },
                        new
                        {
                            Id = new Guid("2f0892c5-f505-4bbf-a363-52f9a6754259"),
                            Name = "Minas Gerais",
                            UFCode = "MG"
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.UrgencyLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("UrgencyLevels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("553b0d79-20c1-49f3-8c2d-820128a293af"),
                            Description = "Sem muita urgência",
                            Priority = 5
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<Guid?>("CityHallId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("FirebaseUserId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .HasColumnType("varchar(45) CHARACTER SET utf8mb4")
                        .HasMaxLength(45);

                    b.Property<string>("LastName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ProfileUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("CityHallId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d4e6519-f440-4272-9c88-45d04f7f447e"),
                            CreationDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "acessa-city-admin@acessacity.com.br",
                            FirebaseUserId = "DDwoQufyCMSU0dE3QqhbvDFHIoa2",
                            FirstName = "Administrador AC"
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.UserRoles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f548d02-cdac-4c00-b2b7-9c088e0f7c81"),
                            RoleId = new Guid("a22497ac-2331-4172-af66-b40fa16e637c"),
                            UserId = new Guid("8d4e6519-f440-4272-9c88-45d04f7f447e")
                        });
                });

            modelBuilder.Entity("AcessaCity.Business.Models.Category", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.Category", "ParentCategory")
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.City", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.State", "CityState")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.CityHall", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.InteractionHistory", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.ReportStatus", "NewReportStatus")
                        .WithMany()
                        .HasForeignKey("NewReportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.ReportStatus", "OldReportStatus")
                        .WithMany()
                        .HasForeignKey("oldReportStatusId");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.InteractionHistoryCommentary", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.InteractionHistoryCommentary", "ParentInteractionHistoryCommentary")
                        .WithMany("InteractionHistoryCommentaries")
                        .HasForeignKey("InteractionHistoryCommentId");

                    b.HasOne("AcessaCity.Business.Models.InteractionHistory", null)
                        .WithMany("Commentaries")
                        .HasForeignKey("InteractionHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.Report", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "Coordinator")
                        .WithMany()
                        .HasForeignKey("CoordinatorId");

                    b.HasOne("AcessaCity.Business.Models.ReportStatus", "ReportStatus")
                        .WithMany()
                        .HasForeignKey("ReportStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.UrgencyLevel", "UrgencyLevel")
                        .WithMany()
                        .HasForeignKey("UrgencyLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportAttachment", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.Report", "Report")
                        .WithMany("Attachments")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportClassification", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportCommentary", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.ReportInProgress", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.InteractionHistory", "InteractionHistory")
                        .WithMany()
                        .HasForeignKey("InteractionHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "OwnerUser")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");

                    b.HasOne("AcessaCity.Business.Models.Report", "Report")
                        .WithMany()
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AcessaCity.Business.Models.User", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.CityHall", "CityHall")
                        .WithMany("Users")
                        .HasForeignKey("CityHallId");
                });

            modelBuilder.Entity("AcessaCity.Business.Models.UserRoles", b =>
                {
                    b.HasOne("AcessaCity.Business.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcessaCity.Business.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
