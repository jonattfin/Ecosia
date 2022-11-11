using Ecosia.SearchEngine.Application.Features.Search.Queries;
using Shouldly;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Search;

public class SearchTests
{
    private readonly RepositoryFacade _repositoryFacade;

    public SearchTests()
    {
        _repositoryFacade = new RepositoryFacade();
    }

    [Fact]
    public async Task GetSearchesListTest()
    {
        // Arrange
        var handler = new GetSearchesListQueryHandler(_repositoryFacade.SearchRepositoryMock.Object, _repositoryFacade.Mapper);

        // Act
        var (text, page, size) = ("hello", 1, 5);
        var result = await handler.Handle(new GetSearchesListQuery(text, page, size), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<List<SearchesListVm>>();
        result.Count.ShouldBe(0);
    }
}