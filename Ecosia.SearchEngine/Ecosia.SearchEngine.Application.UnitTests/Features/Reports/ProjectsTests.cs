using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Features.Reports.Commands;
using Ecosia.SearchEngine.Application.Features.Reports.Queries;
using Ecosia.SearchEngine.Application.Features.Reportts.Commands;
using Moq;
using Shouldly;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Reports;

public class ReportsTests
{
    private readonly DatabaseRepository _repository;

    public ReportsTests()
    {
        _repository = new DatabaseRepository();
    }

    [Fact]
    public async Task GetReportsListTest()
    {
        // Arrange
        var handler = new GetReportsListQueryHandler(_repository.ReportRepositoryMock.Object,
            _repository.Mapper);

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
        var query = new GetReportDetailQuery(_repository.Reports.First().Id);
        var handler = new GetReportDetailQueryHandler(_repository.ReportRepositoryMock.Object,
            _repository.Mapper);

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
        var handler = new CreateReportCommandHandler(_repository.ReportRepositoryMock.Object, _repository.Mapper,
            emailServiceMock.Object);

        // Act
        var command = new CreateReportCommand() { TotalIncome = 100, TreesFinanced = 10};
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.ShouldBeOfType<Guid>();
        _repository.Reports.Count.ShouldBe(5);
    }

    [Fact]
    public async Task UpdateReportTest()
    {
        // Arrange
        var handler = new UpdateReportCommandHandler(_repository.ReportRepositoryMock.Object, _repository.Mapper);

        // Act
        var command = new UpdateReportCommand() { Id = _repository.Reports[0].Id, TotalIncome = 1000};
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _repository.Reports[0].TotalIncome.ShouldBe(1000);
    }

    [Fact]
    public async Task DeleteReportTest()
    {
        // Arrange
        var handler = new DeleteReportCommandHandler(_repository.ReportRepositoryMock.Object, _repository.Mapper);

        // Act
        var command = new DeleteReportCommand(_repository.Reports[0].Id);
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _repository.Reports.Count.ShouldBe(3);
    }
}