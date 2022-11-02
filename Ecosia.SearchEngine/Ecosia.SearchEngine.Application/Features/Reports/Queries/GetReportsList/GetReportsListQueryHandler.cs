using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportsListQueryHandler : IRequestHandler<GetReportsListQuery, List<ReportListVm>>
{
    private readonly IAsyncRepository<Report> _reportRepository;
    private readonly IMapper _mapper;

    public GetReportsListQueryHandler(IAsyncRepository<Report> reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<List<ReportListVm>> Handle(GetReportsListQuery request, CancellationToken cancellationToken)
    {
        var reports = await _reportRepository.ListAllAsync();
        return _mapper.Map<List<ReportListVm>>(reports);
    }
}