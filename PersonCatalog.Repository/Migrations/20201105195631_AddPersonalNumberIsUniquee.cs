using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonCatalog.Repository.Migrations
{
    public partial class AddPersonalNumberIsUniquee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_PersonalNumber",
                table: "People",
                column: "PersonalNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_PersonalNumber",
                table: "People");
        }
    }
}
