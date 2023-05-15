using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP_WEB.Models
{
	public class ExperienceProfessionel
	{
		[Required]
		public int ID { get; set; }

        [DisplayName("Nom de l'entreprise")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        [MaxLength(100,ErrorMessage ="Le maximum de caractère est de 100")]
        public string? NomEntreprise { get; set; }

        [DisplayName("Poste Occupé")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        [MaxLength(100)]
        public string? PosteOccupe { get; set; }

        [DisplayName("Description des tâches")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        public string? DescriptionTaches { get; set; }

        [DisplayName("Année d'embauche")]
        [Required(ErrorMessage = "Cette section es obligatoire")]
        public int AnneeEmbauche { get; set; }

        [DisplayName("Année de fin de l'emploi")]
        public int? AnneeFinEmploi { get; set; }

        [DisplayName("Site Internet de l'entreprise")]
        [Url]
        public string? SiteEntreprise { get; set; }


       
	}
}

