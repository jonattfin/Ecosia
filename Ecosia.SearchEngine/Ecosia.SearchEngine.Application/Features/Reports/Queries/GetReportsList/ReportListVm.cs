namespace Ecosia.SearchEngine.Application.Features.Reports.Queries;

public class ReportListVm
{
    public Guid Id { get; set; }
    
    public string Month { get; set; }

    public int Year { get; set; }
    
    public double TotalIncome { get; set; }
    
    public double TreesFinanced { get; set; }
}