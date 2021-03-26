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
        public DbSet<SurveyOption> SurveyOptions { get; set; }
        public DbSet<SurveyLocalization> SurveyLocalizations { get; set; }
        public DbSet<AboutSportHubTranslation> AboutSportHubTranslations { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BannerLocalization> BannerLocalizations { get; set; }
        public DbSet<CompanyInfoSection> CompanyInfoSections { get; set; }
        public DbSet<CompanyInfoTranslation> CompanyInfoTranslations { get; set; }
        public DbSet<ContactUsTranslation> ContactUsTranslations { get; set; }
        public DbSet<ContributorsSection> ContributorsSections { get; set; }
        public DbSet<ContributorsSectionsTranslation> ContributorsSectionsTranslations { get; set; }
        public DbSet<ContributorsTranslation> ContributorsTranslations { get; set; }
        public DbSet<DeletableInfoSectionsTranslation> DeletableInfoSectionsTranslations { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<NewsLetterTranslation> NewsLetterTranslations { get; set; }
        public DbSet<PredefinedBanner> PredefinedBanners { get; set; }
        public DbSet<PredefinedBannerLocalization> PredefinedBannerLocalizations { get; set; }
        public DbSet<Privacy> Privacies { get; set; }
        public DbSet<SurveyOptionLocalization> SurveyOptionLocalizations { get; set; }
        public DbSet<Term> Terms { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SurveyLocalization>().HasKey(e => new { e.SurveyId, e.LanguageId });
            modelBuilder.Entity<SurveyOptionLocalization>().HasKey(e => new { e.SurveyOptionId, e.LanguageId });
            modelBuilder.Entity<BannerLocalization>().HasKey(e => new { e.BannerId, e.LanguageId });
            modelBuilder.Entity<PredefinedBannerLocalization>().HasKey(e => new { e.PredefinedBannerId, e.LanguageId });
            modelBuilder.Entity<ContributorsSectionsTranslation>().HasKey(e => new { e.SectionId, e.LanguageId });
            modelBuilder.Entity<DeletableInfoSectionsTranslation>().HasKey(e => new { e.SectionId, e.LanguageId });
            modelBuilder.Entity<ContactUsTranslation>().HasKey(e => new { e.SectionId, e.LanguageId });
            modelBuilder.Entity<AboutSportHubTranslation>().HasKey(e => new { e.SectionId, e.LanguageId });
            //modelBuilder.Entity<CompanyInfoTranslation>().HasNoKey();
            modelBuilder.Entity<Language>().HasMany(c => c.CompanyInfoTranslations).WithOne(s => s.Language);

        }
    }

}
