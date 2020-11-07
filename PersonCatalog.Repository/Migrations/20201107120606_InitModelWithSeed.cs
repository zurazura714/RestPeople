using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonCatalog.Repository.Migrations
{
    public partial class InitModelWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<byte>(nullable: false),
                    PersonalNumber = table.Column<string>(maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(maxLength: 50, nullable: false),
                    phoneNumberType = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    PersonToID = table.Column<int>(nullable: false),
                    PersonFromID = table.Column<int>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelationType = table.Column<int>(nullable: false),
                    PersonID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => new { x.PersonFromID, x.PersonToID });
                    table.ForeignKey(
                        name: "FK_Relations_People_PersonFromID",
                        column: x => x.PersonFromID,
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
                        name: "FK_Relations_People_PersonToID",
                        column: x => x.PersonToID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "ID", "BirthDate", "Gender", "Name", "PersonalNumber", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, "Zura", "01008048579", "Samkharadze" },
                    { 2, new DateTime(1998, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)2, "Maiko", "01008048580", "Samkharadze" },
                    { 3, new DateTime(1996, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, "Alex", "91008048579", "Dvali" },
                    { 4, new DateTime(1990, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, "Zura", "81008048579", "Esebua" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "ID", "Number", "PersonID", "phoneNumberType" },
                values: new object[,]
                {
                    { 1, "599473377", 1, 1 },
                    { 2, "0322458965", 1, 3 },
                    { 3, "599478523", 2, 1 },
                    { 4, "555555444", 3, 1 },
                    { 5, "599473377", 4, 1 },
                    { 6, "59999957", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Relations",
                columns: new[] { "PersonFromID", "PersonToID", "ID", "PersonID", "RelationType" },
                values: new object[,]
                {
                    { 1, 2, 1, null, 1 },
                    { 1, 3, 2, null, 1 },
                    { 2, 3, 5, null, 4 },
                    { 1, 4, 3, null, 4 },
                    { 2, 4, 4, null, 2 },
                    { 3, 4, 6, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonID",
                table: "PhoneNumbers",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_PersonID",
                table: "Relations",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_PersonToID",
                table: "Relations",
                column: "PersonToID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
