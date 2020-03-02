using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("d4ef1e5f-0cb2-4ac6-b64e-65366a55d897"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Cities",
                type: "decimal(11, 8)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "decimal(11, 8");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Cities",
                type: "decimal(11, 8)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "decimal(11, 8");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirebaseUserId = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 45, nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 200, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProfileUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IBGECode", "Latitude", "Longitude", "Name", "StateId" },
                values: new object[] { new Guid("f6a9d559-8d11-4d95-bd33-0c6bfbd4f0f3"), 3509502, -22.8920565m, -47.2079794m, "Campinas", new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("f6a9d559-8d11-4d95-bd33-0c6bfbd4f0f3"));

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Cities",
                type: "decimal(11, 8",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11, 8)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Cities",
                type: "decimal(11, 8",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11, 8)");

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IBGECode", "Latitude", "Longitude", "Name", "StateId" },
                values: new object[] { new Guid("d4ef1e5f-0cb2-4ac6-b64e-65366a55d897"), 3509502, -22.892056499999999, -47.207979399999999, "Campinas", new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661") });
        }
    }
}
