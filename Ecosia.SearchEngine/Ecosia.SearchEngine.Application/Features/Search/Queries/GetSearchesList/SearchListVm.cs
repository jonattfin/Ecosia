using Ecosia.SearchEngine.Application.Contracts;
using Newtonsoft.Json;

namespace Ecosia.SearchEngine.Application.Features.Search.Queries;

public class PagedSearchesListVm : IPagination<SearchesListVm>
{
    public int Page { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    
    [JsonProperty(PropertyName = "searches")]
    public List<SearchesListVm> Items { get; set; }
}

public class SearchesListVm
{
    public string Name { get; set; }

    public string Snippet { get; set; }
    
    public string Url { get; set; }
}