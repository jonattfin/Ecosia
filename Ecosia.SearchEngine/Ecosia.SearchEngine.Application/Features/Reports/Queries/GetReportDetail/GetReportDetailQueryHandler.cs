using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportDetailQueryHandler : GetReportQueryHandler<GetReportDetailQuery>
{
    public GetReportDetailQueryHandler(IReportRepository reportRepository, IMapper mapper,
        ICountryRepository countryRepository, ICategoryRepository categoryRepository) : base(reportRepository, mapper,
        countryRepository, categoryRepository)
    {
    }

    protected override async Task<Report> GetReport(GetReportDetailQuery query)
    {
        return await ReportRepository.GetByIdAsync(query.Id);
    }
}