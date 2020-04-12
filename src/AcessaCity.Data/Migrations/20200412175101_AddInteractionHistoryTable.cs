using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class AddInteractionHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InteractionHistories");

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
