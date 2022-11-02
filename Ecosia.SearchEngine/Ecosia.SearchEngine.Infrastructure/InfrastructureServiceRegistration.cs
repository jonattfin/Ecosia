using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Infrastructure.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace Ecosia.SearchEngine.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IEmailService, EmailService>();
        
        return services;
    }
}