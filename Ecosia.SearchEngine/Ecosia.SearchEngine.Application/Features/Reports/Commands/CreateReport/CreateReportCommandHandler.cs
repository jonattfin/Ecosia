using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Application.Exceptions;
using Ecosia.SearchEngine.Application.Models.Mail;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    
    public CreateReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailService = emailService;
    }
    
    public async Task<Guid> Handle(CreateReportCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateReportCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        
        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);
            
        var report = _mapper.Map<Report>(command);
        
        report = await _unitOfWork.ReportRepository.AddAsync(report);
        await _unitOfWork.SaveChangesAsync();
        
        try
        {
            var email = new Email { To = "to", Body = "body", Subject = "subject" };
            await _emailService.SendEmail(email);
        }
        catch (Exception e)
        {
            // TODO
            // Console.WriteLine(e);
        }

        return report.Id;
    }
}