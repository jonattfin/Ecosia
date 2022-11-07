using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Seed;

public class MemoryInventory : IInventory
{
    public MemoryInventory()
    {
        Projects = GenerateProjects();
        Reports = GenerateReports();
        Searches = GenerateSearches();
        Tags = GenerateTags(Projects);

        Countries = GenerateCountries();
        Categories = GenerateCategories();

        CategoriesInvestments = GenerateCategoriesInvestments(Reports, Categories);
        CountriesInvestments = GenerateCountriesInvestments(Reports, Countries);
    }

    #region Properties

    public IList<Project> Projects { get; }
    public IList<Report> Reports { get; }

    public IList<Tag> Tags { get; }

    public IList<Search> Searches { get; }

    public IList<Country> Countries { get; }
    public IList<Category> Categories { get; }

    public IList<CategoryInvestment> CategoriesInvestments { get; }

    public IList<CountryInvestment> CountriesInvestments { get; }

    #endregion

    #region Methods

    private static IList<Project> GenerateProjects()
    {
        return new List<Project>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Your trees in the Philippines",
                Scope = "Tree planting",
                Description =
                    "In the Philippines, we are planting native seedlings to restore the land, and creating agroforestry systems with smallholder farmers.",
                Title = "Restoring forests in the Philippines",
                YearSince = 2020,
                ImageUrl = "https://blog.ecosia.org/content/images/size/w1200/2021/04/Philipinen-header_En.png"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Your trees in Cameroon",
                Scope = "Tree planting",
                Description =
                    "Mount Bamboutos is home to numerous endemic species of primates, birds, amphibians and plants. In recent years, it has undergone severe levels of deforestation and degradation.",
                Title = "Restoring Mount Bamboutos",
                YearSince = 2021,
                ImageUrl = "https://blog.ecosia.org/content/images/size/w1200/2021/02/Cameroon.jpg"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Your trees in Nigeria",
                Scope = "Tree planting",
                Description =
                    "In the last few decades, deforestation has become a huge problem in Nigeria. The timber industry, agriculture, and rapid urbanization have brought ecosystems to the point of collapse.",
                Title = "Rural development and trees can coexist",
                YearSince = 2021,
                ImageUrl = "https://blog.ecosia.org/content/images/size/w1200/2021/04/Nigeria-header_En.png"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Your news in Thailand",
                Scope = "Thailand",
                Description =
                    "In Thailand, we are supporting rubber farmers to transform their monocultures into sustainable agroforestry rubber farms.",
                Title = "From monoculture to sustainable rubber farming",
                YearSince = 2021,
                ImageUrl = "https://blog.ecosia.org/content/images/size/w1200/2021/08/Thailand_header.png"
            }
        };
    }

    private static IList<Report> GenerateReports()
    {
        return Enumerable.Range(1, 20).Select(element => new Report()
        {
            Id = Guid.NewGuid(),
            Month = "May",
            Year = 2022,
            TotalIncome = 100000,
            TreesFinanced = 50000,
        }).ToList();
    }

    private static IList<Search> GenerateSearches()
    {
        return new List<Search>();
    }

    private static List<Tag> GenerateTags(IList<Project> projects)
    {
        return new List<Tag>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Partners",
                Subtitle = "Kennemer Foods, NTFP-EP",
                ProjectId = projects[0].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Title = "Planting method",
                Subtitle = "Nurseries, Rainforestation",
                ProjectId = projects[0].Id
            }
        };
    }

    private static IList<Country> GenerateCountries()
    {
        return new List<Country>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Mexico"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Tanzania"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Kenya"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Brazil"
            },
        };
    }

    private static IList<Category> GenerateCategories()
    {
        return new List<Category>
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Trees"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Green investments"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Taxes and social security"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Spreading the word"
            },
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Operational costs"
            },
        };
    }

    private static IList<CategoryInvestment> GenerateCategoriesInvestments(IEnumerable<Report> reports,
        IEnumerable<Category> categories)
    {
        return new List<CategoryInvestment>
        {
            new()
            {
                Id = Guid.NewGuid(),
                CategoryId = categories.First().Id,
                ReportId = reports.First().Id,
                Amount = 2000,
            },
            new()
            {
                Id = Guid.NewGuid(),
                CategoryId = categories.Last().Id,
                ReportId = reports.First().Id,
                Amount = 3000,
            }
        };
    }

    private static IList<CountryInvestment> GenerateCountriesInvestments(IEnumerable<Report> reports,
        IEnumerable<Country> countries)
    {
        return new List<CountryInvestment>
        {
            new()
            {
                Id = Guid.NewGuid(),
                CountryId = countries.First().Id,
                ReportId = reports.First().Id,
                Amount = 4000,
            },
            new()
            {
                Id = Guid.NewGuid(),
                CountryId = countries.Last().Id,
                ReportId = reports.First().Id,
                Amount = 5000,
            }
        };
    }

    #endregion
}