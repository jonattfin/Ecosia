using AutoMapper;
using Ecosia.SearchEngine.Application.Features.Projects.Queries;
using Ecosia.SearchEngine.Application.Profiles;
using Shouldly;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Projects.Queries;

public class GetProjectsListQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly RepositoryMocks _repository = new();

    public GetProjectsListQueryHandlerTests()
    {
        var configurationProvider = new MapperConfiguration(cfg
            =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }

    [Fact]
    public async Task GetProjectsListTest()
    {
        // Arrange
        var handler = new GetProjectsListQueryHandler(_repository.GetProjectRepositoryMock().Object, _mapper);

        // Act
        var result = await handler.Handle(new GetProjectsListQuery(), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<List<ProjectListVm>>();
        result.Count.ShouldBe(4);
    }
}