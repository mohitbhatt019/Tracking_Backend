using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using TrackingManagementSystem.Models;
using TrackingManagementSystem.Data;
using MimeKit;

namespace TrackingManagementSystem.Repository
{
    public class EmailSenderService : IEmailSender
    {
        private EmailSettings _emailSettings { get; }
        private readonly ApplicationDbContext _context;
        public EmailSenderService(IOptions<EmailSettings> emailSettings, ApplicationDbContext context)
        {
            _emailSettings = emailSettings.Value;
            _context= context;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            Execute(email, subject, htmlMessage).Wait();
            return Task.FromResult(0);
        }

        public async Task Execute(string email, string subject, string message)
        {
            var id = email;
            var recieverId = subject;
            var recieverUserId = message;
            var senderInvitationId = message;
            var senderDetails = _context.Users.Find(message);
            message = "Invitation";
            try
            {
                string toEmail = string.IsNullOrEmpty(email) ? _emailSettings.ToEmail : email;
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "My Email Name")
                };

              
                var FilePath = Directory.GetCurrentDirectory() + "\\Template\\Email.html";
                StreamReader str = new StreamReader(FilePath);
                string MailText = str.ReadToEnd();
                MailText = MailText.Replace("[senderUserId]", recieverUserId)
              .Replace("[date]", DateTime.UtcNow.ToString()).Replace("[time]", DateTime.Now.ToShortTimeString()).Replace("[receiverId]", senderDetails.UserName).Replace("[recieverUserId]", recieverId);
                  var emailMessage = new MimeMessage();
                //  emailMessage.From.Add(MailboxAddress.Parse(_config.GetSection("EmailConfiguration:From").Value));
                //  emailMessage.To.Add(MailboxAddress.Parse(message.ToEmail));
                //  emailMessage.Subject = $"Welcome {message.receiverUserName}";

                var builder = new BodyBuilder();
                builder.HtmlBody = MailText;
                emailMessage.Body = builder.ToMessageBody();

                mail.To.Add(new MailAddress(toEmail));
                mail.CC.Add(new MailAddress(_emailSettings.CcEmail));
                mail.Subject = "Invitiation :" + subject;
    
                // Construct the email body with the invitation link
                //string invitationLink = "https://example.com/invitation"; // Replace with your actual invitation link
                var template = Directory.GetCurrentDirectory() + "\\Template\\Email.html";
                //using StreamReader stream = new StreamReader(template);
                //string emailBody = stream.ReadToEnd();
                mail.Body = MailText;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(_emailSettings.PrimaryDomain,
                    _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail,
                        _emailSettings.UsernamePassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
}
