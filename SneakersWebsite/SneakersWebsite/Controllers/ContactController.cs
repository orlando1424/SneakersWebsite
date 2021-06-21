using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SneakersWebsite.Models;

namespace SneakersWebsite.Controllers
{

    //https://nickolasfisher.com/blog/How-To-Make-a-Basic-Working-Contact-Form-With-ASP-NET-Core-MVC-and-MailKit
    public class ContactController : Controller
    {
        private EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;


        public ContactController(EmailAddress _fromAddress, IEmailService _emailService)
        {
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
        }


        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }



        public IActionResult Contact(ContactFormModel viewModel)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Here is your message: Name: {viewModel.Name}, " +
                    $"Email: {viewModel.Email}, Message: {viewModel.Message}",
                    Subject = "Contact Form Message "
                };

                EmailService.Send(msgToSend);
                return RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
