using BlazorEcommerce.Shared.Exceptions;
using Moq;


namespace BlazorEcommerce.Client.Tests.Unit.Services;
public partial class VirtualizationServiceTests
{
    [Fact]
    public void ShouldThrowServiceExceptionOnTakeSkipIfServiceErrorOccurs()
    {
        // given
        uint someStartAt = GetRandomPositiveNumber();
        uint somePageSize = GetRandomPositiveNumber();
        string randomMessage = GetRandomMessage();
        var serviceException = new Exception(randomMessage);

        var expectedVirtualizationServiceException = new VirtualizationServiceException(serviceException);

        this.dataSourceBrokerMock.Setup(broker => broker.TakeSkip(It.IsAny<uint>(), It.IsAny<uint>())).Throws(serviceException);

        // when
        Action takeSkipAction = () => this.virtualizationService.LoadFirstPage(someStartAt, somePageSize);

        // then
        Assert.Throws<VirtualizationServiceException>(takeSkipAction);
        this.dataSourceBrokerMock.Verify(broker => broker.TakeSkip(It.IsAny<uint>(), It.IsAny<uint>()), Times.Once);
        this.dataSourceBrokerMock.VerifyNoOtherCalls();

    }
}
