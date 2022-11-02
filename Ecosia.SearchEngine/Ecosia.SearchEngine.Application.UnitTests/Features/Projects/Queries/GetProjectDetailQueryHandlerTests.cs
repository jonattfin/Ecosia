using AutoMapper;
using Ecosia.SearchEngine.Application.Contracts.Persistence;
using Ecosia.SearchEngine.Application.Features.Projects.Queries;
using Ecosia.SearchEngine.Application.Profiles;
using Ecosia.SearchEngine.Domain.Entities;
using Moq;
using Shouldly;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Projects.Queries;

public class GetProjectDetailQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IAsyncRepository<Project>> _mockProjectRepository;
    private readonly RepositoryMocks _repository = new();

    public GetProjectDetailQueryHandlerTests()
    {
        var configurationProvider = new MapperConfiguration(cfg
            =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        _mapper = configurationProvider.CreateMapper();
    }
    
    [Fact]
    public async Task GetProjectsDetailsTest()
    {
        // Arrange
        var query = new GetProjectDetailQuery() { Id = _repository.Projects.First().Id };
        var handler = new GetProjectDetailQueryHandler(_repository.GetProjectRepositoryMock().Object, _mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<ProjectDetailVm>();
        result.Id.ShouldBe(query.Id);
    }
}