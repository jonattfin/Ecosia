using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Persistence.Repositories;

public class CountryRepository : BaseRepository<Country>, ICountryRepository
{
    public CountryRepository(EcosiaDbContext context) : base(context)
    {
    }
}