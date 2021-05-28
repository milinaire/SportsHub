using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHubDAL.Migrations
{
    public partial class localization_properties_formatting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutSportHubTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "AboutSportHubTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutSportHubTranslations_Languages_LanguageId",
                table: "AboutSportHubTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfoTranslations_Languages_LanguageId1",
                table: "CompanyInfoTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceTranslations_Conferences_ConferenceId",
                table: "ConferenceTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceTranslations_Languages_LanguageId",
                table: "ConferenceTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactUsTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "ContactUsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactUsTranslations_Languages_LanguageId",
                table: "ContactUsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContributorsSectionsTranslations_ContributorsSections_ContributorsSectionId",
                table: "ContributorsSectionsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContributorsSectionsTranslations_Languages_LanguageId",
                table: "ContributorsSectionsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContributorsTranslations_Languages_LanguageId1",
                table: "ContributorsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_DeletableInfoSectionsTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "DeletableInfoSectionsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_DeletableInfoSectionsTranslations_Languages_LanguageId",
                table: "DeletableInfoSectionsTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsLetterTranslations_Languages_LanguageId1",
                table: "NewsLetterTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamTranslations_Languages_LanguageId",
                table: "TeamTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamTranslations_Teams_TeamId",
                table: "TeamTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamTranslations",
                table: "TeamTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsLetterTranslations",
                table: "NewsLetterTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeletableInfoSectionsTranslations",
                table: "DeletableInfoSectionsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContributorsTranslations",
                table: "ContributorsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContributorsSectionsTranslations",
                table: "ContributorsSectionsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactUsTranslations",
                table: "ContactUsTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceTranslations",
                table: "ConferenceTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyInfoTranslations",
                table: "CompanyInfoTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutSportHubTranslations",
                table: "AboutSportHubTranslations");

            migrationBuilder.RenameTable(
                name: "TeamTranslations",
                newName: "TeamLocalizations");

            migrationBuilder.RenameTable(
                name: "NewsLetterTranslations",
                newName: "NewsLetterLocalizations");

            migrationBuilder.RenameTable(
                name: "DeletableInfoSectionsTranslations",
                newName: "DeletableInfoSectionsLocalizations");

            migrationBuilder.RenameTable(
                name: "ContributorsTranslations",
                newName: "ContributorsLocalizations");

            migrationBuilder.RenameTable(
                name: "ContributorsSectionsTranslations",
                newName: "ContributorsSectionsLocalizations");

            migrationBuilder.RenameTable(
                name: "ContactUsTranslations",
                newName: "ContactUsLocalizations");

            migrationBuilder.RenameTable(
                name: "ConferenceTranslations",
                newName: "ConferenceLocalizations");

            migrationBuilder.RenameTable(
                name: "CompanyInfoTranslations",
                newName: "CompanyInfoLocalizations");

            migrationBuilder.RenameTable(
                name: "CategoryTranslations",
                newName: "CategoryLocalizations");

            migrationBuilder.RenameTable(
                name: "AboutSportHubTranslations",
                newName: "AboutSportHubLocalizations");

            migrationBuilder.RenameIndex(
                name: "IX_TeamTranslations_LanguageId",
                table: "TeamLocalizations",
                newName: "IX_TeamLocalizations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsLetterTranslations_LanguageId1",
                table: "NewsLetterLocalizations",
                newName: "IX_NewsLetterLocalizations_LanguageId1");

            migrationBuilder.RenameIndex(
                name: "IX_DeletableInfoSectionsTranslations_LanguageId",
                table: "DeletableInfoSectionsLocalizations",
                newName: "IX_DeletableInfoSectionsLocalizations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_DeletableInfoSectionsTranslations_CompanyInfoSectionsId",
                table: "DeletableInfoSectionsLocalizations",
                newName: "IX_DeletableInfoSectionsLocalizations_CompanyInfoSectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_ContributorsTranslations_LanguageId1",
                table: "ContributorsLocalizations",
                newName: "IX_ContributorsLocalizations_LanguageId1");

            migrationBuilder.RenameIndex(
                name: "IX_ContributorsSectionsTranslations_LanguageId",
                table: "ContributorsSectionsLocalizations",
                newName: "IX_ContributorsSectionsLocalizations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ContributorsSectionsTranslations_ContributorsSectionId",
                table: "ContributorsSectionsLocalizations",
                newName: "IX_ContributorsSectionsLocalizations_ContributorsSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactUsTranslations_LanguageId",
                table: "ContactUsLocalizations",
                newName: "IX_ContactUsLocalizations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactUsTranslations_CompanyInfoSectionsId",
                table: "ContactUsLocalizations",
                newName: "IX_ContactUsLocalizations_CompanyInfoSectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_ConferenceTranslations_LanguageId",
                table: "ConferenceLocalizations",
                newName: "IX_ConferenceLocalizations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyInfoTranslations_LanguageId1",
                table: "CompanyInfoLocalizations",
                newName: "IX_CompanyInfoLocalizations_LanguageId1");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "CategoryLocalizations",
                newName: "IX_CategoryLocalizations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_AboutSportHubTranslations_LanguageId",
                table: "AboutSportHubLocalizations",
                newName: "IX_AboutSportHubLocalizations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_AboutSportHubTranslations_CompanyInfoSectionsId",
                table: "AboutSportHubLocalizations",
                newName: "IX_AboutSportHubLocalizations_CompanyInfoSectionsId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Banners",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamLocalizations",
                table: "TeamLocalizations",
                columns: new[] { "TeamId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsLetterLocalizations",
                table: "NewsLetterLocalizations",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeletableInfoSectionsLocalizations",
                table: "DeletableInfoSectionsLocalizations",
                columns: new[] { "SectionId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContributorsLocalizations",
                table: "ContributorsLocalizations",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContributorsSectionsLocalizations",
                table: "ContributorsSectionsLocalizations",
                columns: new[] { "SectionId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactUsLocalizations",
                table: "ContactUsLocalizations",
                columns: new[] { "SectionId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceLocalizations",
                table: "ConferenceLocalizations",
                columns: new[] { "ConferenceId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyInfoLocalizations",
                table: "CompanyInfoLocalizations",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryLocalizations",
                table: "CategoryLocalizations",
                columns: new[] { "CategoryId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutSportHubLocalizations",
                table: "AboutSportHubLocalizations",
                columns: new[] { "SectionId", "LanguageId" });

            migrationBuilder.CreateIndex(
                name: "IX_Banners_CategoryId",
                table: "Banners",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSportHubLocalizations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "AboutSportHubLocalizations",
                column: "CompanyInfoSectionsId",
                principalTable: "CompanyInfoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSportHubLocalizations_Languages_LanguageId",
                table: "AboutSportHubLocalizations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Categories_CategoryId",
                table: "Banners",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLocalizations_Categories_CategoryId",
                table: "CategoryLocalizations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryLocalizations_Languages_LanguageId",
                table: "CategoryLocalizations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfoLocalizations_Languages_LanguageId1",
                table: "CompanyInfoLocalizations",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceLocalizations_Conferences_ConferenceId",
                table: "ConferenceLocalizations",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceLocalizations_Languages_LanguageId",
                table: "ConferenceLocalizations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUsLocalizations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "ContactUsLocalizations",
                column: "CompanyInfoSectionsId",
                principalTable: "CompanyInfoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUsLocalizations_Languages_LanguageId",
                table: "ContactUsLocalizations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorsLocalizations_Languages_LanguageId1",
                table: "ContributorsLocalizations",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorsSectionsLocalizations_ContributorsSections_ContributorsSectionId",
                table: "ContributorsSectionsLocalizations",
                column: "ContributorsSectionId",
                principalTable: "ContributorsSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorsSectionsLocalizations_Languages_LanguageId",
                table: "ContributorsSectionsLocalizations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeletableInfoSectionsLocalizations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "DeletableInfoSectionsLocalizations",
                column: "CompanyInfoSectionsId",
                principalTable: "CompanyInfoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeletableInfoSectionsLocalizations_Languages_LanguageId",
                table: "DeletableInfoSectionsLocalizations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsLetterLocalizations_Languages_LanguageId1",
                table: "NewsLetterLocalizations",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamLocalizations_Languages_LanguageId",
                table: "TeamLocalizations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamLocalizations_Teams_TeamId",
                table: "TeamLocalizations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutSportHubLocalizations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "AboutSportHubLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutSportHubLocalizations_Languages_LanguageId",
                table: "AboutSportHubLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Categories_CategoryId",
                table: "Banners");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLocalizations_Categories_CategoryId",
                table: "CategoryLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryLocalizations_Languages_LanguageId",
                table: "CategoryLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyInfoLocalizations_Languages_LanguageId1",
                table: "CompanyInfoLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceLocalizations_Conferences_ConferenceId",
                table: "ConferenceLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceLocalizations_Languages_LanguageId",
                table: "ConferenceLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactUsLocalizations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "ContactUsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactUsLocalizations_Languages_LanguageId",
                table: "ContactUsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContributorsLocalizations_Languages_LanguageId1",
                table: "ContributorsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContributorsSectionsLocalizations_ContributorsSections_ContributorsSectionId",
                table: "ContributorsSectionsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ContributorsSectionsLocalizations_Languages_LanguageId",
                table: "ContributorsSectionsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_DeletableInfoSectionsLocalizations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "DeletableInfoSectionsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_DeletableInfoSectionsLocalizations_Languages_LanguageId",
                table: "DeletableInfoSectionsLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsLetterLocalizations_Languages_LanguageId1",
                table: "NewsLetterLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamLocalizations_Languages_LanguageId",
                table: "TeamLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamLocalizations_Teams_TeamId",
                table: "TeamLocalizations");

            migrationBuilder.DropIndex(
                name: "IX_Banners_CategoryId",
                table: "Banners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamLocalizations",
                table: "TeamLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsLetterLocalizations",
                table: "NewsLetterLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DeletableInfoSectionsLocalizations",
                table: "DeletableInfoSectionsLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContributorsSectionsLocalizations",
                table: "ContributorsSectionsLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContributorsLocalizations",
                table: "ContributorsLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactUsLocalizations",
                table: "ContactUsLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceLocalizations",
                table: "ConferenceLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyInfoLocalizations",
                table: "CompanyInfoLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryLocalizations",
                table: "CategoryLocalizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutSportHubLocalizations",
                table: "AboutSportHubLocalizations");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Banners");

            migrationBuilder.RenameTable(
                name: "TeamLocalizations",
                newName: "TeamTranslations");

            migrationBuilder.RenameTable(
                name: "NewsLetterLocalizations",
                newName: "NewsLetterTranslations");

            migrationBuilder.RenameTable(
                name: "DeletableInfoSectionsLocalizations",
                newName: "DeletableInfoSectionsTranslations");

            migrationBuilder.RenameTable(
                name: "ContributorsSectionsLocalizations",
                newName: "ContributorsSectionsTranslations");

            migrationBuilder.RenameTable(
                name: "ContributorsLocalizations",
                newName: "ContributorsTranslations");

            migrationBuilder.RenameTable(
                name: "ContactUsLocalizations",
                newName: "ContactUsTranslations");

            migrationBuilder.RenameTable(
                name: "ConferenceLocalizations",
                newName: "ConferenceTranslations");

            migrationBuilder.RenameTable(
                name: "CompanyInfoLocalizations",
                newName: "CompanyInfoTranslations");

            migrationBuilder.RenameTable(
                name: "CategoryLocalizations",
                newName: "CategoryTranslations");

            migrationBuilder.RenameTable(
                name: "AboutSportHubLocalizations",
                newName: "AboutSportHubTranslations");

            migrationBuilder.RenameIndex(
                name: "IX_TeamLocalizations_LanguageId",
                table: "TeamTranslations",
                newName: "IX_TeamTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsLetterLocalizations_LanguageId1",
                table: "NewsLetterTranslations",
                newName: "IX_NewsLetterTranslations_LanguageId1");

            migrationBuilder.RenameIndex(
                name: "IX_DeletableInfoSectionsLocalizations_LanguageId",
                table: "DeletableInfoSectionsTranslations",
                newName: "IX_DeletableInfoSectionsTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_DeletableInfoSectionsLocalizations_CompanyInfoSectionsId",
                table: "DeletableInfoSectionsTranslations",
                newName: "IX_DeletableInfoSectionsTranslations_CompanyInfoSectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_ContributorsSectionsLocalizations_LanguageId",
                table: "ContributorsSectionsTranslations",
                newName: "IX_ContributorsSectionsTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ContributorsSectionsLocalizations_ContributorsSectionId",
                table: "ContributorsSectionsTranslations",
                newName: "IX_ContributorsSectionsTranslations_ContributorsSectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ContributorsLocalizations_LanguageId1",
                table: "ContributorsTranslations",
                newName: "IX_ContributorsTranslations_LanguageId1");

            migrationBuilder.RenameIndex(
                name: "IX_ContactUsLocalizations_LanguageId",
                table: "ContactUsTranslations",
                newName: "IX_ContactUsTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_ContactUsLocalizations_CompanyInfoSectionsId",
                table: "ContactUsTranslations",
                newName: "IX_ContactUsTranslations_CompanyInfoSectionsId");

            migrationBuilder.RenameIndex(
                name: "IX_ConferenceLocalizations_LanguageId",
                table: "ConferenceTranslations",
                newName: "IX_ConferenceTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyInfoLocalizations_LanguageId1",
                table: "CompanyInfoTranslations",
                newName: "IX_CompanyInfoTranslations_LanguageId1");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryLocalizations_LanguageId",
                table: "CategoryTranslations",
                newName: "IX_CategoryTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_AboutSportHubLocalizations_LanguageId",
                table: "AboutSportHubTranslations",
                newName: "IX_AboutSportHubTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_AboutSportHubLocalizations_CompanyInfoSectionsId",
                table: "AboutSportHubTranslations",
                newName: "IX_AboutSportHubTranslations_CompanyInfoSectionsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamTranslations",
                table: "TeamTranslations",
                columns: new[] { "TeamId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsLetterTranslations",
                table: "NewsLetterTranslations",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DeletableInfoSectionsTranslations",
                table: "DeletableInfoSectionsTranslations",
                columns: new[] { "SectionId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContributorsSectionsTranslations",
                table: "ContributorsSectionsTranslations",
                columns: new[] { "SectionId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContributorsTranslations",
                table: "ContributorsTranslations",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactUsTranslations",
                table: "ContactUsTranslations",
                columns: new[] { "SectionId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceTranslations",
                table: "ConferenceTranslations",
                columns: new[] { "ConferenceId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyInfoTranslations",
                table: "CompanyInfoTranslations",
                column: "LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslations",
                table: "CategoryTranslations",
                columns: new[] { "CategoryId", "LanguageId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutSportHubTranslations",
                table: "AboutSportHubTranslations",
                columns: new[] { "SectionId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSportHubTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "AboutSportHubTranslations",
                column: "CompanyInfoSectionsId",
                principalTable: "CompanyInfoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSportHubTranslations_Languages_LanguageId",
                table: "AboutSportHubTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Languages_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyInfoTranslations_Languages_LanguageId1",
                table: "CompanyInfoTranslations",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceTranslations_Conferences_ConferenceId",
                table: "ConferenceTranslations",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceTranslations_Languages_LanguageId",
                table: "ConferenceTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUsTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "ContactUsTranslations",
                column: "CompanyInfoSectionsId",
                principalTable: "CompanyInfoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUsTranslations_Languages_LanguageId",
                table: "ContactUsTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorsSectionsTranslations_ContributorsSections_ContributorsSectionId",
                table: "ContributorsSectionsTranslations",
                column: "ContributorsSectionId",
                principalTable: "ContributorsSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorsSectionsTranslations_Languages_LanguageId",
                table: "ContributorsSectionsTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorsTranslations_Languages_LanguageId1",
                table: "ContributorsTranslations",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeletableInfoSectionsTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                table: "DeletableInfoSectionsTranslations",
                column: "CompanyInfoSectionsId",
                principalTable: "CompanyInfoSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeletableInfoSectionsTranslations_Languages_LanguageId",
                table: "DeletableInfoSectionsTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsLetterTranslations_Languages_LanguageId1",
                table: "NewsLetterTranslations",
                column: "LanguageId1",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamTranslations_Languages_LanguageId",
                table: "TeamTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamTranslations_Teams_TeamId",
                table: "TeamTranslations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
