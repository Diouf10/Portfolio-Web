using System.ComponentModel.DataAnnotations;

namespace TP_WEB.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string? NomImage { get; set; }

        [Required]
        public byte[]? ImageData { get; set; }

        [Required]
        public string? ContentType { get; set; }

    }
}
