using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHubDAL.Migrations
{
    public partial class added_partners_advertasing_TeamConferenceCategoryTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisings_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "CategoryTranslations",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslations", x => new { x.CategoryId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConferenceTranslations",
                columns: table => new
                {
                    ConferenceId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConferenceTranslations", x => new { x.ConferenceId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ConferenceTranslations_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConferenceTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamTranslations",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desctiption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamTranslations", x => new { x.TeamId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_TeamTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamTranslations_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisingLocalizations",
                columns: table => new
                {
                    AdvertisingId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisingLocalizations", x => new { x.AdvertisingId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_AdvertisingLocalizations_Advertisings_AdvertisingId",
                        column: x => x.AdvertisingId,
                        principalTable: "Advertisings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdvertisingLocalizations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryAds",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AdvertisingId = table.Column<int>(type: "int", nullable: false),
                    Opened = table.Column<int>(type: "int", nullable: false),
                    Displayed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryAds", x => new { x.AdvertisingId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryAds_Advertisings_AdvertisingId",
                        column: x => x.AdvertisingId,
                        principalTable: "Advertisings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryAds_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsPartners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllovedPartnersId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ApiKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefoultSourses = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsPartners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsPartners_AllovedPartners_AllovedPartnersId",
                        column: x => x.AllovedPartnersId,
                        principalTable: "AllovedPartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPartners",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    Sourses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewsPartnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPartners", x => new { x.PartnerId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryPartners_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPartners_NewsPartners_NewsPartnerId",
                        column: x => x.NewsPartnerId,
                        principalTable: "NewsPartners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisingLocalizations_LanguageId",
                table: "AdvertisingLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisings_ImageId",
                table: "Advertisings",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAds_CategoryId",
                table: "CategoryAds",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPartners_CategoryId",
                table: "CategoryPartners",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPartners_NewsPartnerId",
                table: "CategoryPartners",
                column: "NewsPartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceTranslations_LanguageId",
                table: "ConferenceTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPartners_AllovedPartnersId",
                table: "NewsPartners",
                column: "AllovedPartnersId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTranslations_LanguageId",
                table: "TeamTranslations",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisingLocalizations");

            migrationBuilder.DropTable(
                name: "CategoryAds");

            migrationBuilder.DropTable(
                name: "CategoryPartners");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "ConferenceTranslations");

            migrationBuilder.DropTable(
                name: "TeamTranslations");

            migrationBuilder.DropTable(
                name: "Advertisings");

            migrationBuilder.DropTable(
                name: "NewsPartners");

            migrationBuilder.DropTable(
                name: "AllovedPartners");
        }
    }
}
