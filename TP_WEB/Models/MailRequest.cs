namespace TP_WEB.Models
{
    public class MailRequest
    {
        public string? Email { get; set; }
        public string? Sujet { get; set; }
        public string? Corps { get; set; }
        public List<IFormFile>? PiecesJointes{ get; set; }
    }
}
