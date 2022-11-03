using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public class UpdateReportCommand : IRequest
{
    public Guid Id { get; set; }
    
   public string Month { get; set; }

    public int Year { get; set; }
    
    public double TotalIncome { get; set; }
    
    public double TreesFinanced { get; set; }
}