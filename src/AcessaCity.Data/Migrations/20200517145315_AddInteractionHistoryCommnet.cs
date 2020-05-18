using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class AddInteractionHistoryCommnet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InteractionHistoryCommentaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    InteractionHistoryId = table.Column<Guid>(nullable: false),
                    InteractionHistoryCommentId = table.Column<Guid>(nullable: true),
                    Commentary = table.Column<string>(nullable: true)
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
                        name: "FK_InteractionHistoryCommentaries_Users_UserId",
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
                name: "IX_InteractionHistoryCommentaries_UserId",
                table: "InteractionHistoryCommentaries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionHistories_ReportStatus_NewReportStatusId",
                table: "InteractionHistories",
                column: "NewReportStatusId",
                principalTable: "ReportStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionHistories_Report_ReportId",
                table: "InteractionHistories",
                column: "ReportId",
                principalTable: "Report",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionHistories_Users_UserId",
                table: "InteractionHistories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionHistories_ReportStatus_oldReportStatusId",
                table: "InteractionHistories",
                column: "oldReportStatusId",
                principalTable: "ReportStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InteractionHistories_ReportStatus_NewReportStatusId",
                table: "InteractionHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionHistories_Report_ReportId",
                table: "InteractionHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionHistories_Users_UserId",
                table: "InteractionHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_InteractionHistories_ReportStatus_oldReportStatusId",
                table: "InteractionHistories");

            migrationBuilder.DropTable(
                name: "InteractionHistoryCommentaries");

            migrationBuilder.DropIndex(
                name: "IX_InteractionHistories_NewReportStatusId",
                table: "InteractionHistories");

            migrationBuilder.DropIndex(
                name: "IX_InteractionHistories_ReportId",
                table: "InteractionHistories");

            migrationBuilder.DropIndex(
                name: "IX_InteractionHistories_UserId",
                table: "InteractionHistories");

            migrationBuilder.DropIndex(
                name: "IX_InteractionHistories_oldReportStatusId",
                table: "InteractionHistories");

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
