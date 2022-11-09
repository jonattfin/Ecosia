using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportDetailQueryHandler : IRequestHandler<GetReportDetailQuery, ReportDetailVm>
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;
    private readonly ICountryRepository _countryRepository;
    private readonly ICategoryRepository _categoryRepository;

    public GetReportDetailQueryHandler(IReportRepository reportRepository, IMapper mapper,
        ICountryRepository countryRepository, ICategoryRepository categoryRepository)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
        _countryRepository = countryRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ReportDetailVm> Handle(GetReportDetailQuery query, CancellationToken cancellationToken)
    {
        var report = await _reportRepository.GetByIdAsync(query.Id);

        return new ReportDetailVm()
        {
            Id = report.Id,
            Month = report.Month,
            Year = report.Year,
            TotalIncome = report.TotalIncome,
            TreesFinanced = report.TreesFinanced,
            InvestmentsInCategories = await GetInvestmentsInCategories(report),
            InvestmentsInCountries = await GetInvestmentsInCountries(report)
        };
    }

    private async Task<List<CategoryDetailInvestmentVm>> GetInvestmentsInCategories(Report report)
    {
        var elements = await Task.WhenAll(report.InvestmentsInCategories.Select(async investment =>
            new CategoryDetailInvestmentVm()
            {
                Amount = investment.Amount,
                Id = investment.Id,
                CategoryName = (await _categoryRepository.GetByIdAsync(investment.CategoryId)).Name
            }));

        return elements.ToList();
    }

    private async Task<List<CountryDetailInvestmentVm>> GetInvestmentsInCountries(Report report)
    {
        var elements = await Task.WhenAll(report.InvestmentsInCountries.Select(async investment =>
            new CountryDetailInvestmentVm()
            {
                Amount = investment.Amount,
                Id = investment.Id,
                CountryName = (await _countryRepository.GetByIdAsync(investment.CountryId)).Name
            }));

        return elements.ToList();
    }
}