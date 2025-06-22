using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // You can log the email message here for debugging purposes, or use an email service in production
        return Task.CompletedTask;
    }
}
