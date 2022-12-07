using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetLastReportQueryHandler : GetReportQueryHandler<GetLastReportQuery>
{
    public GetLastReportQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    protected override async Task<Report> GetReport(GetLastReportQuery query)
    {
        return await UnitOfWork.ReportRepository.GetLast();
    }
}