using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHubDAL.Migrations
{
    public partial class db_entity_formatting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactUsLocalizations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "ContactUsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsPartners_AllovedPartners_AllovedPartnersId",
                table: "NewsPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_SportArticle_Articles_ArticleId",
                table: "SportArticle");

            migrationBuilder.DropForeignKey(
                name: "FK_SportArticle_Conferences_ConferenceId",
                table: "SportArticle");

            migrationBuilder.DropForeignKey(
                name: "FK_SportArticle_Locations_LocationId",
                table: "SportArticle");

            migrationBuilder.DropForeignKey(
                name: "FK_SportArticle_Teams_TeamId",
                table: "SportArticle");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId1",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "AllovedPartners");

            migrationBuilder.DropTable(
                name: "FollowedTeams");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserId1",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportArticle",
                table: "SportArticle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Votes");

            migrationBuilder.RenameTable(
                name: "SportArticle",
                newName: "SportArticles");

            migrationBuilder.RenameColumn(
                name: "Ispublished",
                table: "Surveys",
                newName: "IsPublished");

            migrationBuilder.RenameColumn(
                name: "DefoultSourses",
                table: "NewsPartners",
                newName: "DefaultSources");

            migrationBuilder.RenameColumn(
                name: "AllovedPartnersId",
                table: "NewsPartners",
                newName: "AllowedPartnersId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsPartners_AllovedPartnersId",
                table: "NewsPartners",
                newName: "IX_NewsPartners_AllowedPartnersId");

            migrationBuilder.RenameColumn(
                name: "language",
                table: "Languages",
                newName: "LanguageName");

            migrationBuilder.RenameColumn(
                name: "Tel",
                table: "ContactUsLocalizations",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "CompanyInfoSectionsId",
                table: "ContactUsLocalizations",
                newName: "CompanyInfoSectionId");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "ContactUsLocalizations",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_ContactUsLocalizations_CompanyInfoSectionsId",
                table: "ContactUsLocalizations",
                newName: "IX_ContactUsLocalizations_CompanyInfoSectionId");

            migrationBuilder.RenameColumn(
                name: "Datetime",
                table: "Comments",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateOfCreation",
                table: "Advertisings",
                newName: "DateCreated");

            migrationBuilder.RenameIndex(
                name: "IX_SportArticle_TeamId",
                table: "SportArticles",
                newName: "IX_SportArticles_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_SportArticle_LocationId",
                table: "SportArticles",
                newName: "IX_SportArticles_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_SportArticle_ConferenceId",
                table: "SportArticles",
                newName: "IX_SportArticles_ConferenceId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Votes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Terms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "SportArticles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "SportArticles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportArticles",
                table: "SportArticles",
                column: "ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "AllowedPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowedPartners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowedTeam",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedTeam", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FollowedTeam_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowedTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId",
                table: "Votes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedTeam_UserId",
                table: "FollowedTeam",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUsLocalizations_CompanyInfoSections_CompanyInfoSectionId",
                table: "ContactUsLocalizations",
                column: "CompanyInfoSectionId",
                principalTable: "CompanyInfoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPartners_AllowedPartners_AllowedPartnersId",
                table: "NewsPartners",
                column: "AllowedPartnersId",
                principalTable: "AllowedPartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportArticles_Articles_ArticleId",
                table: "SportArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportArticles_Conferences_ConferenceId",
                table: "SportArticles",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportArticles_Locations_LocationId",
                table: "SportArticles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportArticles_Teams_TeamId",
                table: "SportArticles",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactUsLocalizations_CompanyInfoSections_CompanyInfoSectionId",
                table: "ContactUsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsPartners_AllowedPartners_AllowedPartnersId",
                table: "NewsPartners");

            migrationBuilder.DropForeignKey(
                name: "FK_SportArticles_Articles_ArticleId",
                table: "SportArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_SportArticles_Conferences_ConferenceId",
                table: "SportArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_SportArticles_Locations_LocationId",
                table: "SportArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_SportArticles_Teams_TeamId",
                table: "SportArticles");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_AspNetUsers_UserId",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "AllowedPartners");

            migrationBuilder.DropTable(
                name: "FollowedTeam");

            migrationBuilder.DropIndex(
                name: "IX_Votes_UserId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SportArticles",
                table: "SportArticles");

            migrationBuilder.RenameTable(
                name: "SportArticles",
                newName: "SportArticle");

            migrationBuilder.RenameColumn(
                name: "IsPublished",
                table: "Surveys",
                newName: "Ispublished");

            migrationBuilder.RenameColumn(
                name: "DefaultSources",
                table: "NewsPartners",
                newName: "DefoultSourses");

            migrationBuilder.RenameColumn(
                name: "AllowedPartnersId",
                table: "NewsPartners",
                newName: "AllovedPartnersId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsPartners_AllowedPartnersId",
                table: "NewsPartners",
                newName: "IX_NewsPartners_AllovedPartnersId");

            migrationBuilder.RenameColumn(
                name: "LanguageName",
                table: "Languages",
                newName: "language");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "ContactUsLocalizations",
                newName: "Tel");

            migrationBuilder.RenameColumn(
                name: "CompanyInfoSectionId",
                table: "ContactUsLocalizations",
                newName: "CompanyInfoSectionsId");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ContactUsLocalizations",
                newName: "Adress");

            migrationBuilder.RenameIndex(
                name: "IX_ContactUsLocalizations_CompanyInfoSectionId",
                table: "ContactUsLocalizations",
                newName: "IX_ContactUsLocalizations_CompanyInfoSectionsId");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Comments",
                newName: "Datetime");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Advertisings",
                newName: "DateOfCreation");

            migrationBuilder.RenameIndex(
                name: "IX_SportArticles_TeamId",
                table: "SportArticle",
                newName: "IX_SportArticle_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_SportArticles_LocationId",
                table: "SportArticle",
                newName: "IX_SportArticle_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_SportArticles_ConferenceId",
                table: "SportArticle",
                newName: "IX_SportArticle_ConferenceId");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Votes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Votes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Terms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "SportArticle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "SportArticle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SportArticle",
                table: "SportArticle",
                columns: new[] { "ArticleId", "ConferenceId", "TeamId", "LocationId" });

            migrationBuilder.CreateTable(
                name: "AllovedPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllovedPartners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FollowedTeams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowedTeams", x => new { x.TeamId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FollowedTeams_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FollowedTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId1",
                table: "Votes",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedTeams_UserId1",
                table: "FollowedTeams",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUsLocalizations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "ContactUsLocalizations",
                column: "CompanyInfoSectionsId",
                principalTable: "CompanyInfoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsPartners_AllovedPartners_AllovedPartnersId",
                table: "NewsPartners",
                column: "AllovedPartnersId",
                principalTable: "AllovedPartners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SportArticle_Articles_ArticleId",
                table: "SportArticle",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportArticle_Conferences_ConferenceId",
                table: "SportArticle",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportArticle_Locations_LocationId",
                table: "SportArticle",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportArticle_Teams_TeamId",
                table: "SportArticle",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_AspNetUsers_UserId1",
                table: "Votes",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
