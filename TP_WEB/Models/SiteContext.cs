using System;
using Microsoft.EntityFrameworkCore;


namespace TP_WEB.Models
{
	public class SiteContext :DbContext
    {
        public  SiteContext(DbContextOptions<SiteContext> options): base(options)
        {
        }

        public DbSet<ExperienceProfessionel> ExperienceProfessionnels { get; set; }
        public DbSet<FormationAcademique> FormationAcademiques { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ExperienceProfessionel>().ToTable("Experiences");
            //modelBuilder.Entity<FormationAcademique>().ToTable("Fromations");
            //modelBuilder.Entity<Portfolio>().ToTable("Portfolios");
        }
    }
}

