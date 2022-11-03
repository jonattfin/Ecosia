using MediatR;

namespace Ecosia.SearchEngine.Application.Features.Reports.Commands;

public class CreateReportCommand : IRequest<Guid>
{
    public string Month { get; set; }

    public int Year { get; set; }
    
    public double TotalIncome { get; set; }
    
    public double TreesFinanced { get; set; }
}