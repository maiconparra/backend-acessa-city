using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class AddReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Report",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Report",
                type: "decimal(10,9)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Report",
                type: "decimal(10,9)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Accuracy",
                table: "Report",
                type: "decimal(10,9)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

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
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Report",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Report",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,9)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Report",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,9)",
                oldDefaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Accuracy",
                table: "Report",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,9)",
                oldDefaultValue: 0m);

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
