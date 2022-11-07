using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportsListQueryHandler : IRequestHandler<GetReportsListQuery, List<ReportListVm>>
{
    private readonly IReportRepository _reportRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly ICategoryRepository _categoryRepository;

    private readonly IMapper _mapper;

    public GetReportsListQueryHandler(IMapper mapper,
        IReportRepository reportRepository, ICountryRepository countryRepository,
        ICategoryRepository categoryRepository)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
        _countryRepository = countryRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<ReportListVm>> Handle(GetReportsListQuery query, CancellationToken cancellationToken)
    {
        var countries = await _countryRepository.ListAllAsync();
        var categories = await _categoryRepository.ListAllAsync();

        var reports = await _reportRepository.ListAllAsync();

        return reports.Select(report => new ReportListVm()
        {
            Id = report.Id,
            Month = report.Month,
            Year = report.Year,
            TotalIncome = report.TotalIncome,
            TreesFinanced = report.TreesFinanced,
            InvestmentsInCategories = report.InvestmentsInCategories.Select(investment => new CategoryInvestmentVm()
            {
                Amount = investment.Amount,
                CategoryName = categories.First(category => category.Id == investment.CategoryId).Name
            }).ToList(),
            InvestmentsInCountries = report.InvestmentsInCountries.Select(investment => new CountryInvestmentVm()
            {
                Amount = investment.Amount,
                CountryName = countries.First((country => country.Id == investment.CountryId)).Name
            }).ToList()
        }).ToList();
    }
}