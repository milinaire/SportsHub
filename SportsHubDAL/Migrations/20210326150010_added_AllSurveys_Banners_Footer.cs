using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHubDAL.Migrations
{
    public partial class added_AllSurveys_Banners_Footer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banners_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfoSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfoSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContributorsSections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Show = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorsSections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowCompanyInfo = table.Column<bool>(type: "bit", nullable: false),
                    ShowContributors = table.Column<bool>(type: "bit", nullable: false),
                    ShowNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    ShowNewsletterDescription = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PredefinedBanners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedBanners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredefinedBanners_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ispublished = table.Column<bool>(type: "bit", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutSportHubTranslations",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CompanyInfoSectionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSportHubTranslations", x => new { x.SectionId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_AboutSportHubTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                        column: x => x.CompanyInfoSectionsId,
                        principalTable: "CompanyInfoSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AboutSportHubTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BannerLocalizations",
                columns: table => new
                {
                    BannerId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannerLocalizations", x => new { x.BannerId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_BannerLocalizations_Banners_BannerId",
                        column: x => x.BannerId,
                        principalTable: "Banners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BannerLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfoTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfoTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyInfoTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUsTranslations",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyInfoSectionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsTranslations", x => new { x.SectionId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ContactUsTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                        column: x => x.CompanyInfoSectionsId,
                        principalTable: "CompanyInfoSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactUsTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributorsSectionsTranslations",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    ContributorsSectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorsSectionsTranslations", x => new { x.SectionId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ContributorsSectionsTranslations_ContributorsSections_ContributorsSectionId",
                        column: x => x.ContributorsSectionId,
                        principalTable: "ContributorsSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContributorsSectionsTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContributorsTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorsTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContributorsTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeletableInfoSectionsTranslations",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    CompanyInfoSectionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletableInfoSectionsTranslations", x => new { x.SectionId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_DeletableInfoSectionsTranslations_CompanyInfoSections_CompanyInfoSectionsId",
                        column: x => x.CompanyInfoSectionsId,
                        principalTable: "CompanyInfoSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeletableInfoSectionsTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsLetterTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetterTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsLetterTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Privacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Privacies_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terms_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PredefinedBannerLocalizations",
                columns: table => new
                {
                    PredefinedBannerId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredefinedBannerLocalizations", x => new { x.PredefinedBannerId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PredefinedBannerLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredefinedBannerLocalizations_PredefinedBanners_PredefinedBannerId",
                        column: x => x.PredefinedBannerId,
                        principalTable: "PredefinedBanners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyLocalizations",
                columns: table => new
                {
                    SurveyId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyLocalizations", x => new { x.SurveyId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_SurveyLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyLocalizations_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SurveyOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SurveyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyOptions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyOptionLocalizations",
                columns: table => new
                {
                    SurveyOptionId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Option = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyOptionLocalizations", x => new { x.SurveyOptionId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_SurveyOptionLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyOptionLocalizations_SurveyOptions_SurveyOptionId",
                        column: x => x.SurveyOptionId,
                        principalTable: "SurveyOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutSportHubTranslations_CompanyInfoSectionsId",
                table: "AboutSportHubTranslations",
                column: "CompanyInfoSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSportHubTranslations_LanguageId",
                table: "AboutSportHubTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_BannerLocalizations_LanguageId",
                table: "BannerLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_ImageId",
                table: "Banners",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInfoTranslations_LanguageId",
                table: "CompanyInfoTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUsTranslations_CompanyInfoSectionsId",
                table: "ContactUsTranslations",
                column: "CompanyInfoSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUsTranslations_LanguageId",
                table: "ContactUsTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorsSectionsTranslations_ContributorsSectionId",
                table: "ContributorsSectionsTranslations",
                column: "ContributorsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorsSectionsTranslations_LanguageId",
                table: "ContributorsSectionsTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ContributorsTranslations_LanguageId",
                table: "ContributorsTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletableInfoSectionsTranslations_CompanyInfoSectionsId",
                table: "DeletableInfoSectionsTranslations",
                column: "CompanyInfoSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletableInfoSectionsTranslations_LanguageId",
                table: "DeletableInfoSectionsTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetterTranslations_LanguageId",
                table: "NewsLetterTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PredefinedBannerLocalizations_LanguageId",
                table: "PredefinedBannerLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PredefinedBanners_ImageId",
                table: "PredefinedBanners",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Privacies_LanguageId",
                table: "Privacies",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyLocalizations_LanguageId",
                table: "SurveyLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyOptionLocalizations_LanguageId",
                table: "SurveyOptionLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyOptions_SurveyId",
                table: "SurveyOptions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_LanguageId",
                table: "Terms",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutSportHubTranslations");

            migrationBuilder.DropTable(
                name: "BannerLocalizations");

            migrationBuilder.DropTable(
                name: "CompanyInfoTranslations");

            migrationBuilder.DropTable(
                name: "ContactUsTranslations");

            migrationBuilder.DropTable(
                name: "ContributorsSectionsTranslations");

            migrationBuilder.DropTable(
                name: "ContributorsTranslations");

            migrationBuilder.DropTable(
                name: "DeletableInfoSectionsTranslations");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "NewsLetterTranslations");

            migrationBuilder.DropTable(
                name: "PredefinedBannerLocalizations");

            migrationBuilder.DropTable(
                name: "Privacies");

            migrationBuilder.DropTable(
                name: "SurveyLocalizations");

            migrationBuilder.DropTable(
                name: "SurveyOptionLocalizations");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "ContributorsSections");

            migrationBuilder.DropTable(
                name: "CompanyInfoSections");

            migrationBuilder.DropTable(
                name: "PredefinedBanners");

            migrationBuilder.DropTable(
                name: "SurveyOptions");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
