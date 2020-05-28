using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class FirstAppMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(type: "varchar(120)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 36, nullable: false),
                    Denied = table.Column<bool>(nullable: false, defaultValue: false),
                    Approved = table.Column<bool>(nullable: false, defaultValue: false),
                    Review = table.Column<bool>(nullable: false, defaultValue: false),
                    InProgress = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UFCode = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrgencyLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 36, nullable: false),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrgencyLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false),
                    IBGECode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(11, 8)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(11, 8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityHalls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    Address = table.Column<string>(type: "varchar(200)", nullable: true),
                    Number = table.Column<string>(type: "varchar(45)", nullable: true),
                    Neighborhood = table.Column<string>(type: "varchar(120)", nullable: true),
                    ZIPCode = table.Column<string>(type: "varchar(45)", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Verified = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityHalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityHalls_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirebaseUserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 45, nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    CityHallId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProfileUrl = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: true, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CityHalls_CityHallId",
                        column: x => x.CityHallId,
                        principalTable: "CityHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    UrgencyLevelId = table.Column<Guid>(nullable: false),
                    ReportStatusId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Street = table.Column<string>(maxLength: 250, nullable: true),
                    Neighborhood = table.Column<string>(maxLength: 250, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false, defaultValue: 0m),
                    Longitude = table.Column<decimal>(type: "decimal(10,8)", nullable: false, defaultValue: 0m),
                    Accuracy = table.Column<decimal>(type: "decimal(10,8)", nullable: false, defaultValue: 0m),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CoordinatorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_Users_CoordinatorId",
                        column: x => x.CoordinatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Report_ReportStatus_ReportStatusId",
                        column: x => x.ReportStatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_UrgencyLevels_UrgencyLevelId",
                        column: x => x.UrgencyLevelId,
                        principalTable: "UrgencyLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteractionHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false),
                    NewReportStatusId = table.Column<Guid>(nullable: false),
                    oldReportStatusId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionHistories_ReportStatus_NewReportStatusId",
                        column: x => x.NewReportStatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteractionHistories_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteractionHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteractionHistories_ReportStatus_oldReportStatusId",
                        column: x => x.oldReportStatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReportAttachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false),
                    MediaType = table.Column<string>(maxLength: 45, nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportAttachments_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportClassifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportClassifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportClassifications_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportClassifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false),
                    Commentary = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportComments_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteractionHistoryCommentaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    InteractionHistoryId = table.Column<Guid>(nullable: false),
                    InteractionHistoryCommentId = table.Column<Guid>(nullable: true),
                    Commentary = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteractionHistoryCommentaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteractionHistoryCommentaries_InteractionHistoryCommentarie~",
                        column: x => x.InteractionHistoryCommentId,
                        principalTable: "InteractionHistoryCommentaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InteractionHistoryCommentaries_InteractionHistories_Interact~",
                        column: x => x.InteractionHistoryId,
                        principalTable: "InteractionHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InteractionHistoryCommentaries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReporstInProgress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false),
                    InteractionHistoryId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    OwnerUserId = table.Column<Guid>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: true),
                    DoneDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporstInProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReporstInProgress_InteractionHistories_InteractionHistoryId",
                        column: x => x.InteractionHistoryId,
                        principalTable: "InteractionHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReporstInProgress_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReporstInProgress_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReporstInProgress_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ReportStatus",
                columns: new[] { "Id", "Approved", "Description" },
                values: new object[] { new Guid("96afa0df-8ad9-4a44-a726-70582b7bd010"), true, "Aprovado" });

            migrationBuilder.InsertData(
                table: "ReportStatus",
                columns: new[] { "Id", "Denied", "Description" },
                values: new object[] { new Guid("52ccae2e-af86-4fcc-82ea-9234088dbedf"), true, "Negado" });

            migrationBuilder.InsertData(
                table: "ReportStatus",
                columns: new[] { "Id", "Description", "InProgress" },
                values: new object[] { new Guid("c37d9588-1875-44dd-8cf1-6781de7533c3"), "Em progresso", true });

            migrationBuilder.InsertData(
                table: "ReportStatus",
                columns: new[] { "Id", "Description", "Review" },
                values: new object[] { new Guid("48cf5f0f-40c9-4a79-9627-6fd22018f72c"), "Em análise", true });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a134413f-fed2-411d-a157-215a0a5eff03"), "user" },
                    { new Guid("859eca17-0122-489b-8528-9e873ac56f74"), "moderator" },
                    { new Guid("f5e0afe9-f2e1-473c-99bc-01aa12c196ce"), "coordinator" },
                    { new Guid("a22497ac-2331-4172-af66-b40fa16e637c"), "admin" },
                    { new Guid("9620e0d0-ab29-4f23-a409-9f6e05058f60"), "city_hall" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name", "UFCode" },
                values: new object[,]
                {
                    { new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661"), "São Paulo", "SP" },
                    { new Guid("2f0892c5-f505-4bbf-a363-52f9a6754259"), "Minas Gerais", "MG" }
                });

            migrationBuilder.InsertData(
                table: "UrgencyLevels",
                columns: new[] { "Id", "Description", "Priority" },
                values: new object[] { new Guid("553b0d79-20c1-49f3-8c2d-820128a293af"), "Sem muita urgência", 5 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityHallId", "CreationDate", "Email", "FirebaseUserId", "FirstName", "LastName", "ProfileUrl" },
                values: new object[] { new Guid("8d4e6519-f440-4272-9c88-45d04f7f447e"), null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "acessa-city-admin@acessacity.com.br", "DDwoQufyCMSU0dE3QqhbvDFHIoa2", "Administrador AC", null, null });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IBGECode", "Latitude", "Longitude", "Name", "StateId" },
                values: new object[] { new Guid("7ae590f1-c6a4-4bb3-91bf-1e82ea45bb4b"), 3509502, -22.8920565m, -47.2079794m, "Campinas", new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("1f548d02-cdac-4c00-b2b7-9c088e0f7c81"), new Guid("a22497ac-2331-4172-af66-b40fa16e637c"), new Guid("8d4e6519-f440-4272-9c88-45d04f7f447e") });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHalls_CityId",
                table: "CityHalls",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionHistories_NewReportStatusId",
                table: "InteractionHistories",
                column: "NewReportStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionHistories_ReportId",
                table: "InteractionHistories",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionHistories_UserId",
                table: "InteractionHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionHistories_oldReportStatusId",
                table: "InteractionHistories",
                column: "oldReportStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionHistoryCommentaries_InteractionHistoryCommentId",
                table: "InteractionHistoryCommentaries",
                column: "InteractionHistoryCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionHistoryCommentaries_InteractionHistoryId",
                table: "InteractionHistoryCommentaries",
                column: "InteractionHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionHistoryCommentaries_UserId",
                table: "InteractionHistoryCommentaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporstInProgress_InteractionHistoryId",
                table: "ReporstInProgress",
                column: "InteractionHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporstInProgress_OwnerUserId",
                table: "ReporstInProgress",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporstInProgress_ReportId",
                table: "ReporstInProgress",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReporstInProgress_UserId",
                table: "ReporstInProgress",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CategoryId",
                table: "Report",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CityId",
                table: "Report",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_CoordinatorId",
                table: "Report",
                column: "CoordinatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ReportStatusId",
                table: "Report",
                column: "ReportStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UrgencyLevelId",
                table: "Report",
                column: "UrgencyLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_UserId",
                table: "Report",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAttachments_ReportId",
                table: "ReportAttachments",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportClassifications_ReportId",
                table: "ReportClassifications",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportClassifications_UserId",
                table: "ReportClassifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportComments_ReportId",
                table: "ReportComments",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportComments_UserId",
                table: "ReportComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityHallId",
                table: "Users",
                column: "CityHallId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InteractionHistoryCommentaries");

            migrationBuilder.DropTable(
                name: "ReporstInProgress");

            migrationBuilder.DropTable(
                name: "ReportAttachments");

            migrationBuilder.DropTable(
                name: "ReportClassifications");

            migrationBuilder.DropTable(
                name: "ReportComments");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "InteractionHistories");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ReportStatus");

            migrationBuilder.DropTable(
                name: "UrgencyLevels");

            migrationBuilder.DropTable(
                name: "CityHalls");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
