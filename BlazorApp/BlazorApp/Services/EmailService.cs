
using MimeKit;
using MailKit.Net.Smtp;

namespace BlazorApp.Services
{
    public class EmailService
    {
        private readonly RabbitMQService _rabbitMQService;

        public EmailService(RabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public void SendEmail(string to, string subject, string body)
        {
            string mailtrapUsername = Environment.GetEnvironmentVariable("mailtrap_username");
            string mailtrapPassword = Environment.GetEnvironmentVariable("mailtrap_password");


            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Cj", "tanedochristian1@gmail.com"));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.mailtrap.io", 587, false);
                client.Authenticate(mailtrapUsername, mailtrapPassword);
                client.Send(message);
                client.Disconnect(true);
            }

            _rabbitMQService.SendMessage("Email sent to: " + to);
        }
    }
}
