using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcessaCity.Data.Migrations
{
    public partial class FirstMigration : Migration
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
                name: "CityHallRelatedUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CityHallId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityHallRelatedUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityHallRelatedUser_CityHalls_CityHallId",
                        column: x => x.CityHallId,
                        principalTable: "CityHalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityHallRelatedUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                values: new object[] { new Guid("7ae590f1-c6a4-4bb3-91bf-1e82ea45bb4b"), 3509502, -22.8920565m, -47.2079794m, "Campinas", new Guid("b545ceb9-fbde-43c9-bbcc-de62a49e1661") });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHallRelatedUser_CityHallId",
                table: "CityHallRelatedUser",
                column: "CityHallId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHallRelatedUser_UserId",
                table: "CityHallRelatedUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CityHalls_CityId",
                table: "CityHalls",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CityHallRelatedUser");

            migrationBuilder.DropTable(
                name: "CityHalls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
