using FluentAssertions;
using Moq;

namespace BlazorEcommerce.Client.Tests.Unit.Services;
public partial class VirtualizationServiceTests
{
    [Fact]
    public void ShouldSkipAndTakeOnLoadFirstPageFromDataSource()
    {
        //given
        uint randomPosition = GetRandomPositiveNumber();
        uint randomPageSize = GetRandomPositiveNumber();
        uint inputPosition = randomPosition;
        uint inputPageSize = randomPageSize;
        uint expectedPageSize = inputPageSize;
        uint expectedPosition = inputPosition;

        IQueryable<object> randomQueryable = CreateRandomQueryable();

        IQueryable<object> returnedQueryable = randomQueryable;
        IQueryable<object> expectedQueryable = returnedQueryable;

        this.dataSourceBrokerMock.Setup(source =>
        source.TakeSkip(inputPosition, inputPageSize)).Returns(returnedQueryable);

        // when
        IQueryable<object> actualQueryable = this.virtualizationService.LoadFirstPage(inputPosition, inputPageSize);

        uint actualPosition = this.virtualizationService.GetCurrentPosition();
        uint actualPageSize = this.virtualizationService.GetPageSize();

        // then
        actualQueryable.Should().BeEquivalentTo(expectedQueryable);
        actualPosition.Should().Be(actualPosition);
        actualPageSize.Should().Be(expectedPageSize);

        this.dataSourceBrokerMock.Verify(source =>
        source.TakeSkip(inputPosition, inputPageSize), Times.Once);

        this.dataSourceBrokerMock.VerifyNoOtherCalls();

    }

    [Fact]
    public void ShouldRetrieveNextPage()
    {
        //given
        uint randomPosition = GetRandomPositiveNumber();
        uint randomPageSize = GetRandomPositiveNumber();
        uint inputPosition = randomPosition;
        uint inputPageSize = randomPageSize;

        //  next page = position + pagesize
        uint expectedNewPosition = inputPosition + inputPageSize;
        uint expectedCurrentPosition = expectedNewPosition;
        uint expectedPageSize = inputPageSize;

        IQueryable<object> retrievedNextPage = CreateRandomQueryable();

        IQueryable<object> expectedNextPage = retrievedNextPage;

        this.dataSourceBrokerMock.Setup(broker => broker.TakeSkip(expectedNewPosition, inputPageSize)).Returns(retrievedNextPage);

        // when
        this.virtualizationService.LoadFirstPage(inputPosition, inputPageSize);

        IQueryable<object> actualNextPage = this.virtualizationService.RetrieveNextPage();

        uint actualCurrentPosition = this.virtualizationService.GetCurrentPosition();

        uint actualPageSize = this.virtualizationService.GetPageSize();


        // then
        actualNextPage.Should().BeEquivalentTo(expectedNextPage);
        actualCurrentPosition.Should().Be(expectedCurrentPosition);
        actualPageSize.Should().Be(expectedPageSize);

        this.dataSourceBrokerMock.Verify(broker => broker.TakeSkip(inputPosition, inputPageSize), Times.Once);

        this.dataSourceBrokerMock.Verify(broker => broker.TakeSkip(expectedNewPosition, inputPageSize), Times.Once);

        this.dataSourceBrokerMock.VerifyNoOtherCalls();

    }
}
