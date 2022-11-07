using Ecosia.SearchEngine.Application.Seed;
using Ecosia.SearchEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecosia.SearchEngine.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var inventory = InventoryFactory.CreateInventory();
        
        modelBuilder.Entity<Project>().HasData(inventory.Projects);
        modelBuilder.Entity<Tag>().HasData(inventory.Tags);

        modelBuilder.Entity<Country>().HasData(inventory.Countries);
        modelBuilder.Entity<Category>().HasData(inventory.Categories);
        modelBuilder.Entity<Report>().HasData(inventory.Reports);

        modelBuilder.Entity<CategoryInvestment>().HasData(inventory.CategoriesInvestments);
        modelBuilder.Entity<CountryInvestment>().HasData(inventory.CountriesInvestments);
    }
}