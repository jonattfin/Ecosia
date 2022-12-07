using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Application.Exceptions;
using Ecosia.SearchEngine.Application.Models.Mail;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    private readonly ILogger<CreateProjectCommandHandler> _logger;
    
    public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, ILogger<CreateProjectCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailService = emailService;
        _logger = logger;
    }
    
    public async Task<Guid> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProjectCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);
            
        var project = _mapper.Map<Project>(command);
        
        project = await _unitOfWork.ProjectRepository.AddAsync(project);
        await _unitOfWork.SaveChangesAsync();
        
        try
        {
            var email = new Email { To = "to", Body = "body", Subject = "subject" };
            await _emailService.SendEmail(email);
        }
        catch (Exception e)
        {
            _logger.LogError("Exception while sending the email", e);
        }

        return project.Id;
    }
}