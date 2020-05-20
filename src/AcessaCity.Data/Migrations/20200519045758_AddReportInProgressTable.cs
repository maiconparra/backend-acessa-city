using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class AddReportInProgressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_InteractionHistoryCommentaries_InteractionHistoryId",
                table: "InteractionHistoryCommentaries",
                column: "InteractionHistoryId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_InteractionHistoryCommentaries_InteractionHistories_Interact~",
                table: "InteractionHistoryCommentaries",
                column: "InteractionHistoryId",
                principalTable: "InteractionHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InteractionHistoryCommentaries_InteractionHistories_Interact~",
                table: "InteractionHistoryCommentaries");

            migrationBuilder.DropTable(
                name: "ReporstInProgress");

            migrationBuilder.DropIndex(
                name: "IX_InteractionHistoryCommentaries_InteractionHistoryId",
                table: "InteractionHistoryCommentaries");

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
