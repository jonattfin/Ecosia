using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public DeleteReportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteReportCommand command, CancellationToken cancellationToken)
    {
        var reportToDelete = await _unitOfWork.ReportRepository.GetByIdAsync(command.Id);

        await _unitOfWork.ReportRepository.DeleteAsync(reportToDelete);
        await _unitOfWork.SaveChangesAsync();
        
        return Unit.Value;
    }
}