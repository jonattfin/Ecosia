using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;
    
    public UpdateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateReportCommand command, CancellationToken cancellationToken)
    {
        var reportToUpdate = await _reportRepository.GetByIdAsync(command.Id);
        _mapper.Map(command, reportToUpdate, typeof(UpdateReportCommand), typeof(Report));

        await _reportRepository.UpdateAsync(reportToUpdate);

        return Unit.Value;
    }
}