using Microsoft.EntityFrameworkCore;
using XMLScraper.Entities;

namespace XMLScraper.Data
{
    public class XMLScraperDbContext: DbContext
    {
        public DbSet<ClientDemographic> ClientDemographics { get; set; }
        public DbSet<ClinicalVisit> ClinicalVisits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=VINCENT-PC\SQLEXPRESS;Database=XMLDump;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
