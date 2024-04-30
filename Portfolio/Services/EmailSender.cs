using System.Net.Mail;

namespace Portfolio.Services
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }

    
    public class EmailSender : IEmailSender
    {
        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {


            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SENDING_EMAIL, Constants.SENDING_PASSWORD);

                try
                {
                    await smtpClient.SendMailAsync(
                        new MailMessage(
                            Constants.SENDING_EMAIL,
                            email,
                            subject,
                            message
                        ));
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    Console.WriteLine($"{e.StackTrace}");
                }


                return false;
            }
        }
    }
    
}
