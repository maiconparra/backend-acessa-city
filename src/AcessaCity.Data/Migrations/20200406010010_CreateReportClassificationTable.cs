using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class CreateReportClassificationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrgencyLevel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrgencyLevel", x => x.Id);
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<decimal>(nullable: false),
                    Accuracy = table.Column<decimal>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
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
                        name: "FK_Report_ReportStatus_ReportStatusId",
                        column: x => x.ReportStatusId,
                        principalTable: "ReportStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_UrgencyLevel_UrgencyLevelId",
                        column: x => x.UrgencyLevelId,
                        principalTable: "UrgencyLevel",
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

            migrationBuilder.UpdateData(
                table: "ReportStatus",
                keyColumn: "Id",
                keyValue: new Guid("48cf5f0f-40c9-4a79-9627-6fd22018f72c"),
                column: "Review",
                value: true);

            migrationBuilder.UpdateData(
                table: "ReportStatus",
                keyColumn: "Id",
                keyValue: new Guid("52ccae2e-af86-4fcc-82ea-9234088dbedf"),
                column: "Denied",
                value: true);

            migrationBuilder.UpdateData(
                table: "ReportStatus",
                keyColumn: "Id",
                keyValue: new Guid("96afa0df-8ad9-4a44-a726-70582b7bd010"),
                column: "Approved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ReportStatus",
                keyColumn: "Id",
                keyValue: new Guid("c37d9588-1875-44dd-8cf1-6781de7533c3"),
                column: "InProgress",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_Report_CategoryId",
                table: "Report",
                column: "CategoryId");

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
                name: "IX_ReportClassifications_ReportId",
                table: "ReportClassifications",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportClassifications_UserId",
                table: "ReportClassifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportClassifications");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "UrgencyLevel");

            migrationBuilder.UpdateData(
                table: "ReportStatus",
                keyColumn: "Id",
                keyValue: new Guid("48cf5f0f-40c9-4a79-9627-6fd22018f72c"),
                column: "Review",
                value: true);

            migrationBuilder.UpdateData(
                table: "ReportStatus",
                keyColumn: "Id",
                keyValue: new Guid("52ccae2e-af86-4fcc-82ea-9234088dbedf"),
                column: "Denied",
                value: true);

            migrationBuilder.UpdateData(
                table: "ReportStatus",
                keyColumn: "Id",
                keyValue: new Guid("96afa0df-8ad9-4a44-a726-70582b7bd010"),
                column: "Approved",
                value: true);

            migrationBuilder.UpdateData(
                table: "ReportStatus",
                keyColumn: "Id",
                keyValue: new Guid("c37d9588-1875-44dd-8cf1-6781de7533c3"),
                column: "InProgress",
                value: true);
        }
    }
}
