using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportDetailQueryHandler : IRequestHandler<GetReportDetailQuery, ReportDetailVm>
{
    private readonly IAsyncRepository<Report> _reportRepository;
    private readonly IMapper _mapper;

    public GetReportDetailQueryHandler(IAsyncRepository<Report> reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }

    public async Task<ReportDetailVm> Handle(GetReportDetailQuery request, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ReportDetailVm>(report);
    }
}