using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;
using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public abstract class GetReportQueryHandler<TQ> : IRequestHandler<TQ, ReportDetailVm>
    where TQ : IRequest<ReportDetailVm>
{
    protected IUnitOfWork UnitOfWork { get; }
    
    private readonly IMapper _mapper;

    protected GetReportQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ReportDetailVm> Handle(TQ query, CancellationToken cancellationToken)
    {
        var report = await GetReport(query);

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

    protected abstract Task<Report> GetReport(TQ query);

    private async Task<List<CategoryDetailInvestmentVm>> GetInvestmentsInCategories(Report report)
    {
        var elements = await Task.WhenAll(report.InvestmentsInCategories.Select(async investment =>
            new CategoryDetailInvestmentVm()
            {
                Amount = investment.Amount,
                Id = investment.Id,
                CategoryName = (await UnitOfWork.CategoryRepository.GetByIdAsync(investment.CategoryId)).Name
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
                CountryName = (await UnitOfWork.CountryRepository.GetByIdAsync(investment.CountryId)).Name
            }));

        return elements.ToList();
    }
}