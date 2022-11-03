using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;
    
    public DeleteReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteReportCommand command, CancellationToken cancellationToken)
    {
        var reportToDelete = await _reportRepository.GetByIdAsync(command.Id);

        await _reportRepository.DeleteAsync(reportToDelete);

        return Unit.Value;
    }
}