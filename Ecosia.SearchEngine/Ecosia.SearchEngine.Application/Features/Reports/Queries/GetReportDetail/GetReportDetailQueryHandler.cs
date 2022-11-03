using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportDetailQueryHandler : IRequestHandler<GetReportDetailQuery, ReportDetailVm>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public GetReportDetailQueryHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<ReportDetailVm> Handle(GetReportDetailQuery query, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetByIdAsync(query.Id);
        return _mapper.Map<ReportDetailVm>(report);
    }
}