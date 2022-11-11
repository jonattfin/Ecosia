using Ecosia.SearchEngine.Application.Contracts.Infrastructure;

namespace Ecosia.SearchEngine.Infrastructure.Search;

public class BingSearchRepository : ISearchRepository
{
    private const int NUMBER_OF_ITEMS = 30;

    public async Task<IEnumerable<Domain.Entities.Search>> ListAllAsync(string text, int page, int size)
    {
        var results = Enumerable.Range(1, NUMBER_OF_ITEMS).Select(element
                => new Domain.Entities.Search
                {
                    Name = $"name {element} {text}",
                    Snippet = $"snippet {element}",
                    Url = $"url {element}"
                })
            .Skip((page - 1) * size)
            .Take(size);

        return await Task.FromResult(results);
    }

    public async Task<int> CountAsync()
    {
        return await Task.FromResult(NUMBER_OF_ITEMS);
    }
}