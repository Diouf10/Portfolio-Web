using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TP_WEB.Models
{
	public class FormationAcademique
	{
        [Required]
        public int ID { get; set; }

        [DisplayName("Nom de l'école")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        [MaxLength(100, ErrorMessage = "Le maximum de caractère est de 100")]
        public string? NomEcole { get; set; }

        [DisplayName("Programme d'étude")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        [MaxLength(100, ErrorMessage = "Le maximum de caractère est de 100")]
        public string? ProgrammeEtude { get; set; }

        [DisplayName("Année de début de la formation")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        public int AnneeDebutFormation { get; set; }

        [DisplayName("Année de fin de la formation ")]
        public int? AnneeFinFormation { get; set; }

        [DisplayName("Lien du programme d'études")]
        [Url]
        public string? LienProgrammeEtude { get; set; }

        [DisplayName("Diplôme obtenu")]
        public bool EstDiplomeObtenu { get; set; }

        
       
    }
}

