using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHubDAL.Migrations
{
    public partial class team_localization_description_column_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Desctiption",
                table: "TeamLocalizations",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TeamLocalizations",
                newName: "Desctiption");
        }
    }
}
