using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Productivity_Tool.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly UserService _userService;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, UserService userService)
        {
            _userService = userService;
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            _userService.Add(new User()
            {
                EmailAddress = email
            }); // This is a bad solution but currently do not know how else to do this
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("marksussex6@gmail.com", Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
