using Ixy.AppService.Interface;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace Ixy.AppService
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public AuthMessageSenderOptions Options { get; }

        public AuthMessageSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }


        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            //var myMessage = new SendGrid.SendGridMessage();
            //myMessage.AddTo(email);
            //myMessage.From = new MailAddress("Joe@contoso.com", "Joe Smith");
            //myMessage.Subject = subject;
            //myMessage.Text = message;
            //myMessage.Html = message;
            //var credentials = new System.Net.NetworkCredential(
            //    Options.SendGridUser,
            //    Options.SendGridKey);
            //// Create a Web transport for sending email.
            //var transportWeb = new SendGrid.Web(credentials);
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Goixy", "sgwzxg@hotmail.com"));
            mimeMessage.To.Add(new MailboxAddress(email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart()
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp-mail.outlook.com", 587, false);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                //string username,string password
                
                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("sgwzxg@hotmail.com", "**********");

                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
            //return transportWeb.DeliverAsync(myMessage);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }

    }
}
