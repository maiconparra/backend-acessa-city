using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class CreateReportStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportStatus");
        }
    }
}
