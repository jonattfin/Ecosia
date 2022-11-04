using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Features.Reports.Commands;
using Ecosia.SearchEngine.Application.Features.Reports.Queries;
using Moq;
using Shouldly;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Reports;

public class ReportsTests
{
    private readonly RepositoryFacade _repositoryFacade;

    public ReportsTests()
    {
        _repositoryFacade = new RepositoryFacade();
    }

    [Fact]
    public async Task GetReportsListTest()
    {
        // Arrange
        var handler = new GetReportsListQueryHandler(_repositoryFacade.ReportRepositoryMock.Object,
            _repositoryFacade.Mapper);

        // Act
        var result = await handler.Handle(new GetReportsListQuery(), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<List<ReportListVm>>();
        result.Count.ShouldBe(4);
    }

    [Fact]
    public async Task GetReportsDetailsTest()
    {
        // Arrange
        var query = new GetReportDetailQuery(_repositoryFacade.Reports.First().Id);
        var handler = new GetReportDetailQueryHandler(_repositoryFacade.ReportRepositoryMock.Object,
            _repositoryFacade.Mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<ReportDetailVm>();
        result.Id.ShouldBe(query.Id);
    }

    [Fact]
    public async Task CreateReportTest()
    {
        // Arrange
        var emailServiceMock = new Mock<IEmailService>();
        var handler = new CreateReportCommandHandler(_repositoryFacade.ReportRepositoryMock.Object, _repositoryFacade.Mapper,
            emailServiceMock.Object);

        // Act
        var command = new CreateReportCommand() { TotalIncome = 100, TreesFinanced = 10};
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<Guid>();
        _repositoryFacade.Reports.Count.ShouldBe(5);
    }

    [Fact]
    public async Task UpdateReportTest()
    {
        // Arrange
        var handler = new UpdateReportCommandHandler(_repositoryFacade.ReportRepositoryMock.Object, _repositoryFacade.Mapper);

        // Act
        var command = new UpdateReportCommand() { Id = _repositoryFacade.Reports[0].Id, TotalIncome = 1000};
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _repositoryFacade.Reports[0].TotalIncome.ShouldBe(1000);
    }

    [Fact]
    public async Task DeleteReportTest()
    {
        // Arrange
        var handler = new DeleteReportCommandHandler(_repositoryFacade.ReportRepositoryMock.Object, _repositoryFacade.Mapper);

        // Act
        var command = new DeleteReportCommand(_repositoryFacade.Reports[0].Id);
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _repositoryFacade.Reports.Count.ShouldBe(3);
    }
}