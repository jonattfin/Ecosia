namespace Ecosia.SearchEngine.Application.Contracts;

public interface IPagination<T>
{
    int Page { get; set; }
    int Size { get; set; }
    int Count { get; set; }
    public List<T> Items { get; set; }
}