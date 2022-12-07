using Ecosia.SearchEngine.Application.Contracts;
using Newtonsoft.Json;

namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class PagedReportsListVm : IPagination<ReportListVm>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }

    [JsonProperty(PropertyName = "reports")]
    public List<ReportListVm> Items { get; set; }
}

public class ReportListVm
{
    public Guid Id { get; set; }

    public byte Month { get; set; }

    public int Year { get; set; }

    public double TotalIncome { get; set; }

    public double TreesFinanced { get; set; }

    public List<CategoryInvestmentVm> InvestmentsInCategories { get; set; }

    public List<CountryInvestmentVm> InvestmentsInCountries { get; set; }
}

public class CategoryInvestmentVm
{
    public string CategoryName { get; set; }
    public double Amount { get; set; }
}

public class CountryInvestmentVm
{
    public string CountryName { get; set; }
    public double Amount { get; set; }
}