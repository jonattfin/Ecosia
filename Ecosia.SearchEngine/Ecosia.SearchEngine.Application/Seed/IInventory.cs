using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Seed;

public interface IInventory
{
    IList<Project> Projects { get; }
    IList<Report> Reports { get; }
    IList<Tag> Tags { get; }
    IList<Search> Searches { get; }
    IList<Country> Countries { get; }
    IList<Category> Categories { get; }
    IList<CategoryInvestment> CategoriesInvestments { get; }
    IList<CountryInvestment> CountriesInvestments { get; }
}