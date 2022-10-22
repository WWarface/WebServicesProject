using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace WebServicesProject.Services
{
    public class EmailSender:IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Student", "2003harik2003@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", "matyiokin2002@gmail.com"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("Plain")
            {
                Text = message
            };


            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 465);
                await client.AuthenticateAsync("2003harik2003@gmail.com", "zeqjkmqgsxiwypba");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
