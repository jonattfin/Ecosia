using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public UpdateReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateReportCommand command, CancellationToken cancellationToken)
    {
        var reportToUpdate = await _unitOfWork.ReportRepository.GetByIdAsync(command.Id);
        _mapper.Map(command, reportToUpdate, typeof(UpdateReportCommand), typeof(Report));

        await _unitOfWork.ReportRepository.UpdateAsync(reportToUpdate);
        await _unitOfWork.SaveChangesAsync();

        return Unit.Value;
    }
}