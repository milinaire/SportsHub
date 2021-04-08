using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsHubDAL.Migrations
{
    public partial class added_db_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminPermissions",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockUsers = table.Column<bool>(type: "bit", nullable: false),
                    DeleteUsers = table.Column<bool>(type: "bit", nullable: false),
                    CreateOrDeleteAdmins = table.Column<bool>(type: "bit", nullable: false),
                    CreateOrDeleteArticles = table.Column<bool>(type: "bit", nullable: false),
                    CreateOrDeleteCategories = table.Column<bool>(type: "bit", nullable: false),
                    CreateOrDeleteAd = table.Column<bool>(type: "bit", nullable: false),
                    CreateOrDeleteBanners = table.Column<bool>(type: "bit", nullable: false),
                    AddOrDeleteLanguage = table.Column<bool>(type: "bit", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminPermissions", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AdminPermissions_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    IsEditable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowComments = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
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
                    ShowCompanyInfo = table.Column<bool>(type: "bit", nullable: false),
                    ShowContributors = table.Column<bool>(type: "bit", nullable: false),
                    ShowNewsletter = table.Column<bool>(type: "bit", nullable: false),
                    ShowNewsletterDescription = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
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
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialNetvorks",
                columns: table => new
                {
                    ShowShare = table.Column<bool>(type: "bit", nullable: false),
                    ShowFollow = table.Column<bool>(type: "bit", nullable: false),
                    ShowLoginOrSignUp = table.Column<bool>(type: "bit", nullable: false),
                    AllowShareVideos = table.Column<bool>(type: "bit", nullable: false),
                    ShowShareFacebook = table.Column<bool>(type: "bit", nullable: false),
                    ShowShareGoogle = table.Column<bool>(type: "bit", nullable: false),
                    ShowShareTwitter = table.Column<bool>(type: "bit", nullable: false),
                    ShowFollowFacebook = table.Column<bool>(type: "bit", nullable: false),
                    ShowFollowGoogle = table.Column<bool>(type: "bit", nullable: false),
                    ShowFollowTwitter = table.Column<bool>(type: "bit", nullable: false),
                    ShowFollowYoutube = table.Column<bool>(type: "bit", nullable: false),
                    ShowLoginOrSignUpFacebook = table.Column<bool>(type: "bit", nullable: false),
                    ShowLoginOrSignUpGoogle = table.Column<bool>(type: "bit", nullable: false),
                    ShowLoginOrSignUpTwitter = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
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
                name: "Conferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conferences_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Views",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Views", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Views_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Views_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ContentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Contents_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Contents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "CompanyInfoTranslations",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId1 = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfoTranslations", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_CompanyInfoTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
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
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId1 = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributorsTranslations", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_ContributorsTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
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
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId1 = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetterTranslations", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_NewsLetterTranslations_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Privacies",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId1 = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Privacies", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_Privacies_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terms",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId1 = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms", x => x.LanguageId);
                    table.ForeignKey(
                        name: "FK_Terms_Languages_LanguageId1",
                        column: x => x.LanguageId1,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Homes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShowPhotoOfTheDay = table.Column<bool>(type: "bit", nullable: false),
                    PhotoOfTheDayImgId = table.Column<int>(type: "int", nullable: true),
                    ShowMostPopular = table.Column<bool>(type: "bit", nullable: false),
                    ShowMostCommented = table.Column<bool>(type: "bit", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Homes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Homes_Images_PhotoOfTheDayImgId",
                        column: x => x.PhotoOfTheDayImgId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Homes_Periods_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "Periods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "CategoryPartners",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    NewsPartnerId = table.Column<int>(type: "int", nullable: false),
                    Sourses = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPartners", x => new { x.NewsPartnerId, x.CategoryId });
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
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConferenceId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Show = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dislike = table.Column<bool>(type: "bit", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VideoLocalization",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoLocalization", x => new { x.VideoId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_VideoLocalization_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoLocalization_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
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
                name: "ArticleLocalization",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Headline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleLocalization", x => new { x.ArticleId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_ArticleLocalization_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleLocalization_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "PhotoOfTheDayLocalization",
                columns: table => new
                {
                    PhotoOfTheDayId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    HomeId = table.Column<int>(type: "int", nullable: true),
                    PhotoOfTheDayAlt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoOfTheDayTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoOfTheDayDesciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoOfTheDayAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoOfTheDayLocalization", x => new { x.PhotoOfTheDayId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PhotoOfTheDayLocalization_Homes_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Homes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhotoOfTheDayLocalization_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SurveyOptionsId = table.Column<int>(type: "int", nullable: true),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => new { x.OptionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Votes_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Votes_SurveyOptions_SurveyOptionsId",
                        column: x => x.SurveyOptionsId,
                        principalTable: "SurveyOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreakDowns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Show = table.Column<bool>(type: "bit", nullable: false),
                    ConferenceId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakDowns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreakDowns_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreakDowns_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BreakDowns_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "NewsLetterSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    All = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ConferenceId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLetterSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsLetterSubscriptions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsLetterSubscriptions_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsLetterSubscriptions_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NewsLetterSubscriptions_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportArticle",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ConferenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportArticle", x => new { x.ArticleId, x.ConferenceId, x.TeamId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_SportArticle_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportArticle_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportArticle_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportArticle_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
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

            migrationBuilder.CreateIndex(
                name: "IX_AboutSportHubTranslations_CompanyInfoSectionsId",
                table: "AboutSportHubTranslations",
                column: "CompanyInfoSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSportHubTranslations_LanguageId",
                table: "AboutSportHubTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminPermissions_UserId1",
                table: "AdminPermissions",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisingLocalizations_LanguageId",
                table: "AdvertisingLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisings_ImageId",
                table: "Advertisings",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLocalization_LanguageId",
                table: "ArticleLocalization",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ContentId",
                table: "Articles",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BannerLocalizations_LanguageId",
                table: "BannerLocalizations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Banners_ImageId",
                table: "Banners",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakDowns_CategoryId",
                table: "BreakDowns",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakDowns_ConferenceId",
                table: "BreakDowns",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BreakDowns_TeamId",
                table: "BreakDowns",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAds_CategoryId",
                table: "CategoryAds",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPartners_CategoryId",
                table: "CategoryPartners",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslations_LanguageId",
                table: "CategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ContentId",
                table: "Comments",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInfoTranslations_LanguageId1",
                table: "CompanyInfoTranslations",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_CategoryId",
                table: "Conferences",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceTranslations_LanguageId",
                table: "ConferenceTranslations",
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
                name: "IX_ContributorsTranslations_LanguageId1",
                table: "ContributorsTranslations",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_DeletableInfoSectionsTranslations_CompanyInfoSectionsId",
                table: "DeletableInfoSectionsTranslations",
                column: "CompanyInfoSectionsId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletableInfoSectionsTranslations_LanguageId",
                table: "DeletableInfoSectionsTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowedTeams_UserId1",
                table: "FollowedTeams",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_PeriodId",
                table: "Homes",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_Homes_PhotoOfTheDayImgId",
                table: "Homes",
                column: "PhotoOfTheDayImgId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainArticles_ArticleId",
                table: "MainArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetterSubscriptions_CategoryId",
                table: "NewsLetterSubscriptions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetterSubscriptions_ConferenceId",
                table: "NewsLetterSubscriptions",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetterSubscriptions_LanguageId",
                table: "NewsLetterSubscriptions",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetterSubscriptions_TeamId",
                table: "NewsLetterSubscriptions",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLetterTranslations_LanguageId1",
                table: "NewsLetterTranslations",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_NewsPartners_AllovedPartnersId",
                table: "NewsPartners",
                column: "AllovedPartnersId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoOfTheDayLocalization_HomeId",
                table: "PhotoOfTheDayLocalization",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoOfTheDayLocalization_LanguageId",
                table: "PhotoOfTheDayLocalization",
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
                name: "IX_Privacies_LanguageId1",
                table: "Privacies",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_SportArticle_ConferenceId",
                table: "SportArticle",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_SportArticle_LocationId",
                table: "SportArticle",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SportArticle_TeamId",
                table: "SportArticle",
                column: "TeamId");

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
                name: "IX_Teams_ConferenceId",
                table: "Teams",
                column: "ConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ImageId",
                table: "Teams",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LocationId",
                table: "Teams",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamTranslations_LanguageId",
                table: "TeamTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_LanguageId1",
                table: "Terms",
                column: "LanguageId1");

            migrationBuilder.CreateIndex(
                name: "IX_VideoLocalization_LanguageId",
                table: "VideoLocalization",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ContentId",
                table: "Videos",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Views_ContentId",
                table: "Views",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Views_UserId",
                table: "Views",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_SurveyOptionsId",
                table: "Votes",
                column: "SurveyOptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserId1",
                table: "Votes",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutSportHubTranslations");

            migrationBuilder.DropTable(
                name: "AdminPermissions");

            migrationBuilder.DropTable(
                name: "AdvertisingLocalizations");

            migrationBuilder.DropTable(
                name: "ArticleLocalization");

            migrationBuilder.DropTable(
                name: "BannerLocalizations");

            migrationBuilder.DropTable(
                name: "BreakDowns");

            migrationBuilder.DropTable(
                name: "CategoryAds");

            migrationBuilder.DropTable(
                name: "CategoryPartners");

            migrationBuilder.DropTable(
                name: "CategoryTranslations");

            migrationBuilder.DropTable(
                name: "CompanyInfoTranslations");

            migrationBuilder.DropTable(
                name: "ConferenceTranslations");

            migrationBuilder.DropTable(
                name: "ContactUsTranslations");

            migrationBuilder.DropTable(
                name: "ContributorsSectionsTranslations");

            migrationBuilder.DropTable(
                name: "ContributorsTranslations");

            migrationBuilder.DropTable(
                name: "DeletableInfoSectionsTranslations");

            migrationBuilder.DropTable(
                name: "FollowedTeams");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "MainArticles");

            migrationBuilder.DropTable(
                name: "NewsLetterSubscriptions");

            migrationBuilder.DropTable(
                name: "NewsLetterTranslations");

            migrationBuilder.DropTable(
                name: "PhotoOfTheDayLocalization");

            migrationBuilder.DropTable(
                name: "PredefinedBannerLocalizations");

            migrationBuilder.DropTable(
                name: "Privacies");

            migrationBuilder.DropTable(
                name: "SocialNetvorks");

            migrationBuilder.DropTable(
                name: "SportArticle");

            migrationBuilder.DropTable(
                name: "SurveyLocalizations");

            migrationBuilder.DropTable(
                name: "SurveyOptionLocalizations");

            migrationBuilder.DropTable(
                name: "TeamTranslations");

            migrationBuilder.DropTable(
                name: "Terms");

            migrationBuilder.DropTable(
                name: "VideoLocalization");

            migrationBuilder.DropTable(
                name: "Views");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Banners");

            migrationBuilder.DropTable(
                name: "Advertisings");

            migrationBuilder.DropTable(
                name: "NewsPartners");

            migrationBuilder.DropTable(
                name: "ContributorsSections");

            migrationBuilder.DropTable(
                name: "CompanyInfoSections");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Homes");

            migrationBuilder.DropTable(
                name: "PredefinedBanners");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "SurveyOptions");

            migrationBuilder.DropTable(
                name: "AllovedPartners");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropTable(
                name: "Conferences");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
