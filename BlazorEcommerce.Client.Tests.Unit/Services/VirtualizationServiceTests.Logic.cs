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

        uint actualPageSize = this.virtualizationService.GetPageSize();

        // then
        actualQueryable.Should().BeEquivalentTo(expectedQueryable);
        actualPageSize.Should().Be(expectedPageSize);

        this.dataSourceBrokerMock.Verify(source =>
        source.TakeSkip(inputPosition, inputPageSize), Times.Once);

        this.dataSourceBrokerMock.VerifyNoOtherCalls();

    }

}
