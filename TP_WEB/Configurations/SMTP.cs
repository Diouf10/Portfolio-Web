using System;
namespace TP_WEB.Configurations
{
	public class SMTP
	{
		public string? NomServeur { get; set; }
		public int Port { get; set; }
		public string? Utilisateur { get; set; }
		public string? MotDePasse { get; set; }
	}
}

