using ChurchFinanceSite.Models;
using ChurchFinanceSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ChurchFinanceSite.Controllers
{
    [AllowAnonymous]
    public class ContactEmailController : Controller
    {
        // GET: ContactEmail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactEmail contact)
        {
            if (ModelState.IsValid)
            {
                ContactViewModel vm = new ContactViewModel
                {
                    ContactEmail = contact
                };

                // Send email
                try
                {
                    string email = System.Configuration.ConfigurationManager.AppSettings["fromEmail"];
                    string emailpass = System.Configuration.ConfigurationManager.AppSettings["fromEmailPassword"];
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    msg.From = new MailAddress(contact.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.To.Add("bsn.progreat@gmail.com");
                    msg.Subject = "Contact us";
                    msg.IsBodyHtml = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new System.Net.NetworkCredential(email, emailpass);
                    sb.Append("First name: " + contact.FirstName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Last name: " + contact.LastName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + contact.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Comments: " + contact.Comment);
                    msg.Body = sb.ToString();
                    smtp.Send(msg);
                    msg.Dispose();
                    return View("Success", vm);
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            return View(contact);
        }
    }
}