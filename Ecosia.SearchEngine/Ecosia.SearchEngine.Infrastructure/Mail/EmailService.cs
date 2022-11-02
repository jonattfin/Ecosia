using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Models.Mail;

namespace Ecosia.SearchEngine.Infrastructure.Mail;

public class EmailService : IEmailService
{
    public async Task<bool> SendEmail(Email mail)
    {
        Console.WriteLine($"Email sent {mail}");
        return await Task.FromResult(true);
    }
}