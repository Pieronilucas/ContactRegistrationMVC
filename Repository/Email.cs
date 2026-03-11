using MailKit.Net.Smtp;
using MimeKit;

namespace ContactRegistration.Repository;

public class Email : IEmail
{
    private readonly IConfiguration _configuration;
    private string _filepath = "log_email.txt";

    public Email(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public bool SendEmail(string email, string subject, string message)
    {
        try
        {
            string host = _configuration.GetValue<string>("SMTP:Host");
            int port = _configuration.GetValue<int>("SMTP:Port");
            string username = _configuration.GetValue<string>("SMTP:Username");
            string password = _configuration.GetValue<string>("SMTP:Password");
            string name = _configuration.GetValue<string>("SMTP:Name");


            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(name, username));
            emailMessage.To.Add(MailboxAddress.Parse(email));
            emailMessage.Subject = subject;
            
            emailMessage.Body = new TextPart("html") {Text = message};
            
            using SmtpClient smtp = new SmtpClient();
            smtp.Connect(host, port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(username, password);
            smtp.Send(emailMessage);
            smtp.Disconnect(true);
     
            return true;
            
        }
        catch (Exception e)
        {
            string logDir = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logDir);

            string logPath = Path.Combine(logDir, _filepath);
            string logline = $"{DateTime.Now}: {e}\n";
            File.AppendAllText(logPath, logline);
            return false;
        }
    }
}