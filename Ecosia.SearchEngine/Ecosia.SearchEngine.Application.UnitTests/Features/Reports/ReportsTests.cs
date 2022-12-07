using Ecosia.SearchEngine.Application.Contracts.Infrastructure;
using Ecosia.SearchEngine.Application.Features.Reports.Commands;
using Ecosia.SearchEngine.Application.Features.Reports.Queries;
using FluentAssertions;
using Moq;

namespace Ecosia.SearchEngine.Application.UnitTests.Features.Reports;

public class ReportsTests
{
    private readonly UnitOfWorkFacade _unitOfWorkFacade;

    public ReportsTests()
    {
        _unitOfWorkFacade = new UnitOfWorkFacade();
    }

    [Fact]
    public async Task GetReportsListTest()
    {
        // Arrange
        var handler = new GetReportsListQueryHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper);

        // Act
        var result = await handler.Handle(new GetReportsListQuery(1, 10), CancellationToken.None);

        // Assert
        result.Should().BeOfType<PagedReportsListVm>();
        result.Count.Should().Be(12);
    }

    [Fact]
    public async Task GetReportsDetailsTest()
    {
        // Arrange
        var query = new GetReportDetailQuery(_unitOfWorkFacade.Inventory.Reports.First().Id);
        var handler = new GetReportDetailQueryHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeOfType<ReportDetailVm>();
        result.Id.Should().Be(query.Id);
    }

    [Fact]
    public async Task CreateReportTest()
    {
        // Arrange
        var emailServiceMock = new Mock<IEmailService>();
        var handler = new CreateReportCommandHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper,
            emailServiceMock.Object);

        // Act
        var command = new CreateReportCommand { TotalIncome = 100, TreesFinanced = 10};
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkFacade.Inventory.Reports.Count().Should().Be(13);
    }

    [Fact]
    public async Task UpdateReportTest()
    {
        // Arrange
        var handler = new UpdateReportCommandHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper);

        // Act
        var command = new UpdateReportCommand { Id = _unitOfWorkFacade.Inventory.Reports.First().Id, TotalIncome = 1000};
        await handler.Handle(command, CancellationToken.None);

        // Assert
        _unitOfWorkFacade.Inventory.Reports.First().TotalIncome.Should().Be(1000);
    }

    [Fact]
    public async Task DeleteReportTest()
    {
        // Arrange
        var handler = new DeleteReportCommandHandler(_unitOfWorkFacade.UnitOfWorkMock.Object, _unitOfWorkFacade.Mapper);

        // Act
        var command = new DeleteReportCommand(_unitOfWorkFacade.Inventory.Reports.First().Id);
        await handler.Handle(command, CancellationToken.None);

        // Assert
       _unitOfWorkFacade.Inventory.Reports.Count().Should().Be(11);
    }
}