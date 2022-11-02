using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Application.Exceptions;
using Ecosia.SearchEngine.Application.Models.Mail;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Projects.Commands;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    
    public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper, IEmailService emailService)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
        _emailService = emailService;
    }
    
    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProjectCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new ValidationException(validationResult);
            
        var project = _mapper.Map<Project>(request);
        project = await _projectRepository.AddAsync(project);

        try
        {
            var email = new Email() { To = "to", Body = "body", Subject = "subject" };
            await _emailService.SendEmail(email);
        }
        catch (Exception e)
        {
            // TODO
            // Console.WriteLine(e);
        }

        return project.Id;
    }
}