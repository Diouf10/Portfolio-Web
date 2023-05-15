using System.Diagnostics;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using TP_WEB.Configurations;
using TP_WEB.Models;

namespace TP_WEB.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IConfiguration _configuration;
    private readonly SMTPConfig configSMTP;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IOptions<SMTPConfig> config)
    {
        _logger = logger;
        _configuration = configuration;
        configSMTP = config.Value;

    }
    public IActionResult EnvoyerCourriel(string TxtObjet, string TxtMessage)
    {

        //var adresseServeur = _configuration.GetValue<string>("MesConfigs:SMTP:AdresseServeur");
        //var port = _configuration.GetValue<int>("MesConfigs:SMTP:Port");
        //var utilisateur = _configuration.GetValue<string>("MesConfigs:SMTP:Utilisateurs");
        //var motDePasse = _configuration.GetValue<string>("MesConfigs:SMTP:MotDePasse");

        var adresseServeur = configSMTP.AdresseServeur;
        var port = configSMTP.Port;
        var utilisateur = configSMTP.Utilisateur;
        var motDePasse = configSMTP.MotDePasse;

        //Instanciation du client
        SmtpClient smtpClient = new SmtpClient(adresseServeur, port);
        //On indique au client d'utiliser les informations qu'on va lui fournir
        smtpClient.UseDefaultCredentials = false;
        //Ajout des informations de connexion
        smtpClient.Credentials = new System.Net.NetworkCredential(utilisateur, motDePasse);
        //On indique que l'on envoie le mail par le réseau
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //On active le protocole SSL
        smtpClient.EnableSsl = true;

        MailMessage mail = new MailMessage();
        //Expéditeur
        mail.From = new MailAddress(utilisateur!, "Courriel");
        //Destinataire
        mail.To.Add(new MailAddress("1936603@cstjean.qc.ca"));

        mail.Subject = TxtObjet;
        mail.Body = TxtMessage;

        smtpClient.Send(mail);
        return View("MessageEnvoye");
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult A_propos()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult TelechargerCv()
    {
        return File("~/docs/cv_Diouf_Mouhammad.pdf", "application/pdf");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

