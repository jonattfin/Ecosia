using Ecosia.SearchEngine.Domain.Entities;

namespace Ecosia.SearchEngine.Application.Contracts.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
}