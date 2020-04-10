using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class AddUrgencyLevelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_UrgencyLevel_UrgencyLevelId",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrgencyLevel",
                table: "UrgencyLevel");

            migrationBuilder.RenameTable(
                name: "UrgencyLevel",
                newName: "UrgencyLevels");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UrgencyLevels",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrgencyLevels",
                table: "UrgencyLevels",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "UrgencyLevels",
                columns: new[] { "Id", "Description", "Priority" },
                values: new object[] { new Guid("553b0d79-20c1-49f3-8c2d-820128a293af"), "Sem muita urgência", 5 });

            migrationBuilder.AddForeignKey(
                name: "FK_Report_UrgencyLevels_UrgencyLevelId",
                table: "Report",
                column: "UrgencyLevelId",
                principalTable: "UrgencyLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Report_UrgencyLevels_UrgencyLevelId",
                table: "Report");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UrgencyLevels",
                table: "UrgencyLevels");

            migrationBuilder.DeleteData(
                table: "UrgencyLevels",
                keyColumn: "Id",
                keyValue: new Guid("553b0d79-20c1-49f3-8c2d-820128a293af"));

            migrationBuilder.RenameTable(
                name: "UrgencyLevels",
                newName: "UrgencyLevel");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UrgencyLevel",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 36);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UrgencyLevel",
                table: "UrgencyLevel",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Report_UrgencyLevel_UrgencyLevelId",
                table: "Report",
                column: "UrgencyLevelId",
                principalTable: "UrgencyLevel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
