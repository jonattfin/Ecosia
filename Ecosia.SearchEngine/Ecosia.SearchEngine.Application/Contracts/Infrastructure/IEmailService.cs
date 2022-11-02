using Ecosia.SearchEngine.Application.Models.Mail;

namespace Ecosia.SearchEngine.Application.Contracts.Infrastructure;

public interface IEmailService
{
    Task<bool> SendEmail(Email mail);
}