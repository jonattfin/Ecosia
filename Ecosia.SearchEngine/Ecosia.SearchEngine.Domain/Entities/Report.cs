using Ecosia.SearchEngine.Domain.Common;

namespace Ecosia.SearchEngine.Domain.Entities;

public class Report : AuditableEntity
{
    public Guid Id { get; set; }

    public int Year { get; set; }
    
    public byte Month { get; set; }
    
    public double TotalIncome { get; set; }
    
    public double TreesFinanced { get; set; }

    public List<CategoryInvestment> InvestmentsInCategories { get; set; } = new();

    public List<CountryInvestment> InvestmentsInCountries { get; set; } = new();
}