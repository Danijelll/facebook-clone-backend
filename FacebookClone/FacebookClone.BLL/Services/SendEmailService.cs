using FacebookClone.BLL.Services.Abstract;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace FacebookClone.BLL.Services
{
    public class SendEmailService : ISendEmailService
    {
        private IConfiguration _configuration;
        private const string URL = "https://localhost:5001/";

        public SendEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private void SendEmail(MimeMessage email)
        {
            using SmtpClient smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 465, true);
            smtp.Authenticate(_configuration["GmailAccountUsername"], _configuration["GmailAccountPassword"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SendConfimCodeEmail(string emailReciver, string username, string emailHash)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["GmailAccountUsername"]));
            email.To.Add(MailboxAddress.Parse(emailReciver));
            email.Subject = "Your Email Confirmation";
            email.Body = new TextPart(TextFormat.Text) { Text = $"Hello { username }, \n Please go to the following url to confirm your email \n { URL }confirmMail/{ emailHash }" };

            SendEmail(email);
        }

        public void Send2FACodeEmail(string emailReciver, string username, string twoFactorCode)
        {
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["GmailAccountUsername"]));
            email.To.Add(MailboxAddress.Parse(emailReciver));
            email.Subject = "Your 2FA Code";
            email.Body = new TextPart(TextFormat.Text) { Text = $"Hello { username }, \n This is your 2FA code: { twoFactorCode } \n Please go to the following url and enter the code to login \n { URL }login/{ emailReciver }" };

            SendEmail(email);
        }
    }
}