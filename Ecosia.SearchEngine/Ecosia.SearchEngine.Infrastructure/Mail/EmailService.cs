using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Models.Mail;
using Microsoft.Extensions.Logging;

namespace Ecosia.SearchEngine.Infrastructure.Mail;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }
    
    public async Task<bool> SendEmail(Email mail)
    {
        _logger.LogInformation($"Email sent {mail}");
        return await Task.FromResult(true);
    }
}