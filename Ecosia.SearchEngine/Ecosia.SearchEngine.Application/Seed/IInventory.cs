using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Seed;

public interface IInventory
{
    IList<Project> Projects { get; }
    IList<Report> Reports { get; }
    
    IEnumerable<Tag> Tags { get; }
    IEnumerable<Search> Searches { get; }
    IEnumerable<Country> Countries { get; }
    IEnumerable<Category> Categories { get; }
    IEnumerable<CategoryInvestment> CategoriesInvestments { get; }
    IEnumerable<CountryInvestment> CountriesInvestments { get; }
}