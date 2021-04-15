using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SportsHubDAL.Entities;


namespace SportsHubDAL.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Conference> Conferences { get; set; }

        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyOptions> SurveyOptions { get; set; }
        public DbSet<SurveyLocalization> SurveyLocalizations { get; set; }
        public DbSet<AboutSportHubLocalization> AboutSportHubLocalizations { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BannerLocalization> BannerLocalizations { get; set; }
        public DbSet<CompanyInfoSection> CompanyInfoSections { get; set; }
        public DbSet<CompanyInfoLocalization> CompanyInfoLocalizations { get; set; }
        public DbSet<ContactUsLocalizationn> ContactUsLocalizations { get; set; }
        public DbSet<ContributorsSection> ContributorsSections { get; set; }
        public DbSet<ContributorsSectionsLocalization> ContributorsSectionsLocalizations { get; set; }
        public DbSet<ContributorsLocalization> ContributorsLocalizations { get; set; }
        public DbSet<DeletableInfoSectionsLocalization> DeletableInfoSectionsLocalizations { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<NewsLetterLocalization> NewsLetterLocalizations { get; set; }
        public DbSet<PredefinedBanner> PredefinedBanners { get; set; }
        public DbSet<PredefinedBannerLocalization> PredefinedBannerLocalizations { get; set; }
        public DbSet<Privacy> Privacies { get; set; }
        public DbSet<SurveyOptionLocalization> SurveyOptionLocalizations { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<AdvertisingLocalization> AdvertisingLocalizations { get; set; }
        public DbSet<CategoryAd> CategoryAds { get; set; }
        public DbSet<AllovedPartner> AllovedPartners { get; set; }
        public DbSet<NewsPartner> NewsPartners { get; set; }
        public DbSet<CategoryPartner> CategoryPartners { get; set; }
        public DbSet<TeamLocalization> TeamLocalizations { get; set; }
        public DbSet<ConferenceLocalization> ConferenceLocalizations { get; set; }
        public DbSet<CategoryLocalization> CategoryLocalizations { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<MainArticles> MainArticles { get; set; }
        public DbSet<SocialNetwork> SocialNetvorks { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Views> Views { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<BreakDown> BreakDowns { get; set; }
        public DbSet<NewsLetterSubscription> NewsLetterSubscriptions { get; set; }
        public DbSet<AdminPermissions> AdminPermissions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SurveyLocalization>().HasKey(e => new { e.SurveyId, e.LanguageId });
            modelBuilder.Entity<SurveyOptionLocalization>().HasKey(e => new { e.SurveyOptionId, e.LanguageId });
            modelBuilder.Entity<BannerLocalization>().HasKey(e => new { e.BannerId, e.LanguageId });
            modelBuilder.Entity<PredefinedBannerLocalization>().HasKey(e => new { e.PredefinedBannerId, e.LanguageId });
            modelBuilder.Entity<ContributorsSectionsLocalization>().HasKey(e => new { e.SectionId, e.LanguageId });
            modelBuilder.Entity<DeletableInfoSectionsLocalization>().HasKey(e => new { e.SectionId, e.LanguageId });
            modelBuilder.Entity<ContactUsLocalizationn>().HasKey(e => new { e.SectionId, e.LanguageId });
            modelBuilder.Entity<AboutSportHubLocalization>().HasKey(e => new { e.SectionId, e.LanguageId });
            modelBuilder.Entity<AdvertisingLocalization>().HasKey(e => new { e.AdvertisingId, e.LanguageId });
            modelBuilder.Entity<CategoryAd>().HasKey(e => new { e.AdvertisingId, e.CategoryId });
            modelBuilder.Entity<CategoryPartner>().HasKey(e => new { e.NewsPartnerId, e.CategoryId });
            modelBuilder.Entity<TeamLocalization>().HasKey(e => new { e.TeamId, e.LanguageId });
            modelBuilder.Entity<ConferenceLocalization>().HasKey(e => new { e.ConferenceId, e.LanguageId });
            modelBuilder.Entity<CategoryLocalization>().HasKey(e => new { e.CategoryId, e.LanguageId });
            modelBuilder.Entity<PhotoOfTheDayLocalization>().HasKey(e => new { e.PhotoOfTheDayId, e.LanguageId });
            modelBuilder.Entity<SocialNetwork>()
                .HasNoKey();
            modelBuilder.Entity<Footer>()
                .HasNoKey();
            modelBuilder.Entity<VideoLocalization>()
                .HasKey(e => new { e.VideoId, e.LanguageId });
            modelBuilder.Entity<ArticleLocalization>()
                .HasKey(e => new { e.ArticleId, e.LanguageId });
            modelBuilder.Entity<Votes>()
                .HasKey(e => new { e.OptionId, e.UserId });
            modelBuilder.Entity<FollowedTeams>()
               .HasKey(e => new { e.TeamId, e.UserId });
            modelBuilder.Entity<SportArticle>()
              .HasKey(e => new { e.ArticleId, e.ConferenceId, e.TeamId, e.LocationId });

        }
    }

}
