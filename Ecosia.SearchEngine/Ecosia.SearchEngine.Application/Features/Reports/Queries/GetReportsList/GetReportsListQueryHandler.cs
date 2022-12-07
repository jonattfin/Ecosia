using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using MediatR;
using TaskExtensions = Ecosia.SearchEngine.Application.Extensions.TaskExtensions;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class GetReportsListQueryHandler : IRequestHandler<GetReportsListQuery, PagedReportsListVm>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetReportsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedReportsListVm> Handle(GetReportsListQuery query, CancellationToken cancellationToken)
    {
        var (countries, categories, (reports, count)) =
            await TaskExtensions.ExecuteInParallel(
                _unitOfWork.CountryRepository.ListAllAsync(),
                _unitOfWork.CategoryRepository.ListAllAsync(),
                _unitOfWork.ReportRepository.ListAllAsync(query.Page, query.Size));

        return new PagedReportsListVm()
        {
            Page = query.Page,
            Size = query.Size,
            Count = count,
            Items = reports.Select(report =>
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
            }).ToList()
        };
    }
}