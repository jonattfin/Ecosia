using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportsListQueryHandler : IRequestHandler<GetReportsListQuery, List<ReportListVm>>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public GetReportsListQueryHandler(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<List<ReportListVm>> Handle(GetReportsListQuery query, CancellationToken cancellationToken)
    {
        var reports = await _reportRepository.ListAllAsync();
        return _mapper.Map<List<ReportListVm>>(reports);
    }
}