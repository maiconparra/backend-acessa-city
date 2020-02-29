using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class StateCityAndCityHallTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StateId = table.Column<Guid>(nullable: false),
                    IBGECode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 45, nullable: false),
                    Latitude = table.Column<double>(type: "decimal(11, 8)", nullable: false),
                    Longitude = table.Column<double>(type: "decimal(11, 8)", nullable: false)
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
                    Name = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    ZIPCode = table.Column<string>(nullable: true),
                    Verified = table.Column<bool>(nullable: false)
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

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name", "UFCode" },
                values: new object[] { new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661"), "São Paulo", "SP" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Name", "UFCode" },
                values: new object[] { new Guid("2f0892c5-f505-4bbf-a363-52f9a6754259"), "Minas Gerais", "MG" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IBGECode", "Latitude", "Longitude", "Name", "StateId" },
                values: new object[] { new Guid("d4ef1e5f-0cb2-4ac6-b64e-65366a55d897"), 3509502, -22.892056499999999, -47.207979399999999, "Campinas", new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661") });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHalls_CityId",
                table: "CityHalls",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityHalls");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
