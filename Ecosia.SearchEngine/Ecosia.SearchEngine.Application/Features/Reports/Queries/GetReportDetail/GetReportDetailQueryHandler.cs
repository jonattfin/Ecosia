using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportDetailQueryHandler : GetReportQueryHandler<GetReportDetailQuery>
{
    public GetReportDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override async Task<Report> GetReport(GetReportDetailQuery query)
    {
        return await UnitOfWork.ReportRepository.GetByIdAsync(query.Id);
    }
}