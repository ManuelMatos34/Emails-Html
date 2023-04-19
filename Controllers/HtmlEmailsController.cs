using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace HTML_Emails.Controllers
{
	public class HtmlEmailsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Email(string para, string subject, string body)
		{
			MailMessage mail = new MailMessage();
			mail.To.Add(new MailAddress(para, ""));
			mail.From = new MailAddress("cuposUNPHU@hotmail.com");
			mail.Subject = subject;
			mail.Body = body;
			mail.IsBodyHtml = true;
			SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
			smtp.UseDefaultCredentials = false;
			smtp.EnableSsl = true;
			smtp.Credentials = new System.Net.NetworkCredential("cuposUNPHU@hotmail.com", "1234HOLA");
			smtp.Send(mail);

			return RedirectToAction("Index", "Home");

		}

        public IActionResult HtmlEmail(string para, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(new MailAddress(para, ""));
            mail.From = new MailAddress("cuposUNPHU@hotmail.com");
            mail.Subject = subject;

			string html2 = "<!DOCTYPE html> <html> <head> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\"> </head> <body " +
				"style=\"margin: 0; font-family: Arial, Helvetica, sans-serif;\"> <div style=\"overflow: hidden; background-color: #f1f1f1; padding: " +
				"20px 10px;\" class=\"header\"> <a class=\"logo\">CompanyLogo</a> <div class=\"header-right\"> <a class=\"active\">Home</a> <a>Contact</a> " +
				"<a>About</a> </div> </div> <div style=\"padding-left:20px\"> <h1>Plantilla para Correos</h1> <p>"+body+"</p> " +
				"<p>Cualquier cosa......</p> </div> </body> <footer style=\"text-align: center; padding: 3px; background-color: #f1f1f1; color: white;\"> " +
				"<p style=\"color:blue\">Author: Hege Refsnes<br> <p style=\"color:blue\">hege@example.com</p> </p> </footer> </html>";

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(html2, Encoding.UTF8, MediaTypeNames.Text.Html);
			mail.AlternateViews.Add(alternateView);
            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("cuposUNPHU@hotmail.com", "1234HOLA");
            smtp.Send(mail);

            return RedirectToAction("Index", "Home");

        }
    }
}
