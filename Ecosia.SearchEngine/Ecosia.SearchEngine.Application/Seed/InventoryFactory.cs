using System.Collections.Immutable;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Seed;

public static class InventoryFactory
{
    public static IInventory CreateInventory() => new MemoryInventory();

    private class MemoryInventory : IInventory
    {
        public MemoryInventory()
        {
            Projects = GenerateProjects().ToList();
            Reports = GenerateReports().ToList();
            
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

        public IEnumerable<Tag> Tags { get; }

        public IEnumerable<Search> Searches { get; }

        public IEnumerable<Country> Countries { get; }
        public IEnumerable<Category> Categories { get; }

        public IEnumerable<CategoryInvestment> CategoriesInvestments { get; }

        public IEnumerable<CountryInvestment> CountriesInvestments { get; }

        #endregion

        #region Methods

        private static IEnumerable<Project> GenerateProjects()
        {
            yield return new Project
            {
                Id = Guid.NewGuid(),
                Name = "Your trees in the Philippines",
                Scope = "Tree planting",
                Description =
                    "In the Philippines, we are planting native seedlings to restore the land, and creating agroforestry systems with smallholder farmers.",
                Title = "Restoring forests in the Philippines",
                YearSince = 2020,
                ImageUrl = "https://blog.ecosia.org/content/images/size/w1200/2021/04/Philipinen-header_En.png"
            };

            yield return new Project
            {
                Id = Guid.NewGuid(),
                Name = "Your trees in Cameroon",
                Scope = "Tree planting",
                Description =
                    "Mount Bamboutos is home to numerous endemic species of primates, birds, amphibians and plants. In recent years, it has undergone severe levels of deforestation and degradation.",
                Title = "Restoring Mount Bamboutos",
                YearSince = 2021,
                ImageUrl = "https://blog.ecosia.org/content/images/size/w1200/2021/02/Cameroon.jpg"
            };

            yield return new Project
            {
                Id = Guid.NewGuid(),
                Name = "Your trees in Nigeria",
                Scope = "Tree planting",
                Description =
                    "In the last few decades, deforestation has become a huge problem in Nigeria. The timber industry, agriculture, and rapid urbanization have brought ecosystems to the point of collapse.",
                Title = "Rural development and trees can coexist",
                YearSince = 2021,
                ImageUrl = "https://blog.ecosia.org/content/images/size/w1200/2021/04/Nigeria-header_En.png"
            };

            yield return new Project
            {
                Id = Guid.NewGuid(),
                Name = "Your news in Thailand",
                Scope = "Thailand",
                Description =
                    "In Thailand, we are supporting rubber farmers to transform their monocultures into sustainable agroforestry rubber farms.",
                Title = "From monoculture to sustainable rubber farming",
                YearSince = 2021,
                ImageUrl = "https://blog.ecosia.org/content/images/size/w1200/2021/08/Thailand_header.png"
            };
        }

        private static IEnumerable<Report> GenerateReports()
        {
            var random = new Random();

            return Enumerable.Range(1, 12).Select(element => new Report
            {
                Id = Guid.NewGuid(),
                Month = (byte)element,
                Year = random.Next(2019, 2023),
                TotalIncome = 100000,
                TreesFinanced = 50000,
            });
        }

        private static IEnumerable<Search> GenerateSearches()
        {
            return ImmutableArray<Search>.Empty;
        }

        private static IEnumerable<Tag> GenerateTags(IEnumerable<Project> projects)
        {
            foreach (var project in projects)
            {
                yield return new Tag
                {
                    Id = Guid.NewGuid(),
                    Title = "Partners",
                    Subtitle = "Kennemer Foods, NTFP-EP",
                    ProjectId = project.Id
                };

                yield return new Tag
                {
                    Id = Guid.NewGuid(),
                    Title = "Planting method",
                    Subtitle = "Nurseries, Rainforestation",
                    ProjectId = project.Id
                };
            }
        }

        private static IEnumerable<Country> GenerateCountries()
        {
            yield return new Country
            {
                Id = Guid.NewGuid(),
                Name = "Mexico"
            };

            yield return new Country
            {
                Id = Guid.NewGuid(),
                Name = "Tanzania"
            };

            yield return new Country
            {
                Id = Guid.NewGuid(),
                Name = "Kenya"
            };

            yield return new Country
            {
                Id = Guid.NewGuid(),
                Name = "Brazil"
            };
        }

        private static IEnumerable<Category> GenerateCategories()
        {
            yield return new Category
            {
                Id = Guid.NewGuid(),
                Name = "Trees"
            };
            yield return new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Green investments"
            };
            yield return new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Taxes and social security"
            };
            yield return new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Spreading the word"
            };
            yield return new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Operational costs"
            };
        }

        private static IEnumerable<CategoryInvestment> GenerateCategoriesInvestments(IEnumerable<Report> reports,
            IEnumerable<Category> categories)
        {
            var random = new Random();

            foreach (var report in reports)
            {
                yield return new CategoryInvestment()
                {
                    Id = Guid.NewGuid(),
                    CategoryId = categories.First().Id,
                    ReportId = report.Id,
                    Amount = random.Next(1000, 5000),
                };

                yield return new CategoryInvestment()
                {
                    Id = Guid.NewGuid(),
                    CategoryId = categories.Last().Id,
                    ReportId = report.Id,
                    Amount = random.Next(1000, 5000),
                };
            }
        }

        private static IEnumerable<CountryInvestment> GenerateCountriesInvestments(IEnumerable<Report> reports,
            IEnumerable<Country> countries)
        {
            var random = new Random();

            foreach (var report in reports)
            {
                yield return new()
                {
                    Id = Guid.NewGuid(),
                    CountryId = countries.First().Id,
                    ReportId = report.Id,
                    Amount = random.Next(1000, 5000),
                };
                yield return new()
                {
                    Id = Guid.NewGuid(),
                    CountryId = countries.Last().Id,
                    ReportId = report.Id,
                    Amount = random.Next(1000, 5000),
                };
            }
        }

        #endregion
    }
}