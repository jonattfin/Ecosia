using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetLastReportQueryHandler : GetReportQueryHandler<GetLastReportQuery>
{
    public GetLastReportQueryHandler(IReportRepository reportRepository, IMapper mapper,
        ICountryRepository countryRepository, ICategoryRepository categoryRepository) : base(reportRepository, mapper,
        countryRepository, categoryRepository)
    {
    }

    protected override async Task<Report> GetReport(GetLastReportQuery query)
    {
        return await ReportRepository.GetLast();
    }
}