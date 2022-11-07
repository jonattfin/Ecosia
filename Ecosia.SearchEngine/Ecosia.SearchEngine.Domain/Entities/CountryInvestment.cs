namespace Ecosia.SearchEngine.Domain.Entities;

public class CountryInvestment
{
    public Guid Id { get; set; }

    public Guid CountryId { get; set; }
    
    public Guid ReportId { get; set; }

    public double Amount { get; set; }
}