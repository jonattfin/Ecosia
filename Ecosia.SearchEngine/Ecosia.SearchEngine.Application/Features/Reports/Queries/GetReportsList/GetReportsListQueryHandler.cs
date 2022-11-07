using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;
using TaskExtensions = Ecosia.SearchEngine.Application.Extensions.TaskExtensions;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportsListQueryHandler : IRequestHandler<GetReportsListQuery, List<ReportListVm>>
{
    private readonly IMapper _mapper;

    private readonly IReportRepository _reportRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly ICategoryRepository _categoryRepository;

    public GetReportsListQueryHandler(IMapper mapper,
        IReportRepository reportRepository, ICountryRepository countryRepository,
        ICategoryRepository categoryRepository)
    {
        _mapper = mapper;

        _reportRepository = reportRepository;
        _countryRepository = countryRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<ReportListVm>> Handle(GetReportsListQuery query, CancellationToken cancellationToken)
    {
        var (countries, categories, reports) =
            await TaskExtensions.ExecuteThreeInParallel(
                _countryRepository.ListAllAsync(),
                _categoryRepository.ListAllAsync(),
                _reportRepository.ListAllAsync());

        return reports.Select(report =>
        {
            var reportListVm = _mapper.Map<ReportListVm>(report);

            reportListVm.InvestmentsInCategories = report.InvestmentsInCategories.Select(investment =>
                new CategoryInvestmentVm
                {
                    Amount = investment.Amount,
                    CategoryName = categories.First(category => category.Id == investment.CategoryId).Name
                }).ToList();

            reportListVm.InvestmentsInCountries = report.InvestmentsInCountries.Select(investment =>
                new CountryInvestmentVm
                {
                    Amount = investment.Amount,
                    CountryName = countries.First((country => country.Id == investment.CountryId)).Name
                }).ToList();

            return reportListVm;
        }).ToList();
    }
}