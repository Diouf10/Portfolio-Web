using System;
using System.ComponentModel;
namespace TP_WEB.Models
{
	public class DBInitializer
	{
        public static void Initialize(SiteContext context)
        {
            
            if (context.Portfolios.Any())
                return;   

            var portfolios = new List<Portfolio>()
            {
                new Portfolio
                { 
                    NomProjet="TimFlix", 
                    DescriptionProjet ="un projet de web ait en multimédia", 
                    TypeProjet="Web", 
                    ImageID = 1,
                    TechnologieUtilise ="Css, Html, JS" 
                },
            };
            context.AddRange(portfolios);
            context.SaveChanges();

           

            var formations = new List<FormationAcademique>()
            {
                new FormationAcademique
                {
                    NomEcole= "Cégep Édouard-Montpetit",
                    ProgrammeEtude = "Multimédia",
                    AnneeDebutFormation=2018,
                    AnneeFinFormation=2021,
                    EstDiplomeObtenu = false 
                },
                
            };

            context.AddRange(formations);
            context.SaveChanges();



            var experienceProfessionels = new List<ExperienceProfessionel>()
            {
                new ExperienceProfessionel
                { 
                    NomEntreprise="Exo", 
                    PosteOccupe ="Technicien en informatique", 
                    DescriptionTaches ="technicien" ,
                    AnneeEmbauche=2023
                },
                
            };

            context.AddRange(experienceProfessionels);
            context.SaveChanges();
        }

        public static void CreateDataIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SiteContext>();
                    Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}

