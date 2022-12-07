namespace Ecosia.SearchEngine.Application.UnitTests.Features.Search;

public class SearchTests
{
    private readonly UnitOfWorkFacade _unitOfWorkFacade;

    public SearchTests()
    {
        _unitOfWorkFacade = new UnitOfWorkFacade();
    }

    [Fact]
    public async Task GetSearchesListTest()
    {
        // // Arrange
        // var handler = new GetSearchesListQueryHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper);
        //
        // // Act
        // var (text, page, size) = ("hello", 1, 5);
        // var result = await handler.Handle(new GetSearchesListQuery(text, page, size), CancellationToken.None);
        //
        // // Assert
        // result.Should().BeOfType<PagedSearchesListVm>();
        // result.Count.Should().Be(0);
    }
}