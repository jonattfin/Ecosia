namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class ReportDetailVm
{
    public Guid Id { get; set; }
    
    public string Month { get; set; }

    public int Year { get; set; }
    
    public double TotalIncome { get; set; }
    
    public double TreesFinanced { get; set; }
    
    public List<CategoryDetailInvestmentVm> InvestmentsInCategories { get; set; }

    public List<CountryDetailInvestmentVm> InvestmentsInCountries { get; set; }
}

public class CategoryDetailInvestmentVm
{
    public Guid Id { get; set; }
    public string CategoryName { get; set; }
    public double Amount { get; set; }
}

public class CountryDetailInvestmentVm
{
    public Guid Id { get; set; }
    public string CountryName { get; set; }
    public double Amount { get; set; }
}
