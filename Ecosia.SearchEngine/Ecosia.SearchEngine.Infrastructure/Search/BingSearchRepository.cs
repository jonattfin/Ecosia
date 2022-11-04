using Ecosia.SearchEngine.Application.Contracts.Infrastructure;

namespace Ecosia.SearchEngine.Infrastructure.Search;

public class BingSearchRepository : ISearchRepository
{
    public async Task<IEnumerable<Domain.Entities.Search>> ListAllAsync(string text)
    {
        var results = Enumerable.Range(1, 10).Select(element
            => new Domain.Entities.Search()
            {
                Title = $"title {element} {text}",
                Description = $"description {element}",
                Url = $"url {element}"
            });
        return await Task.FromResult(results);
    }
}