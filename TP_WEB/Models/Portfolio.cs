using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace TP_WEB.Models
{
    public class Portfolio
    {
        [Required]
        public int ID { get; set; }

        [DisplayName("Nom du projet")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        [MaxLength(100, ErrorMessage = "Le maximum de caractère est de 100")]
        public string? NomProjet { get; set; }

        [DisplayName("Description du projet")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        public string? DescriptionProjet { get; set; }

        [DisplayName("Type de projet")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        public string? TypeProjet { get; set; }

        public int ImageID { get; set; }

        [DisplayName("Image")]
        public Image? Image { get; set; }

        [DisplayName("Technologie utilisée")]
        [Required(ErrorMessage = "Cette section est obligatoire")]
        [MaxLength(100, ErrorMessage = "Le maximum de caractère est de 100")]
        public string? TechnologieUtilise { get; set; }

        [DisplayName("Nombre d'heure")]
        public int? NombreHeure { get; set; }

        [DisplayName("Adresse Web")]
        [Url]
        public string? AdresseWeb { get; set; }

        [DisplayName("Rôle dans le projet")]
        public string? RoleProjet { get; set; }

        [DisplayName("Afficher")]
        public bool Afficher { get; set; }
 
	}
}

