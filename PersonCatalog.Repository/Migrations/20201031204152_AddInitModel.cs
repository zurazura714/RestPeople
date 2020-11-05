using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonCatalog.Repository.Migrations
{
    public partial class AddInitModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Gender = table.Column<byte>(nullable: false),
                    PersonalNumber = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(nullable: false),
                    phoneNumberType = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    FromID = table.Column<int>(nullable: false),
                    ToID = table.Column<int>(nullable: false),
                    RelationType = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => new { x.FromID, x.ToID });
                    table.ForeignKey(
                        name: "FK_Relations_People_FromID",
                        column: x => x.FromID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_People_ToID",
                        column: x => x.ToID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_PersonID",
                table: "PhoneNumber",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_PersonID",
                table: "Relations",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_ToID",
                table: "Relations",
                column: "ToID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
