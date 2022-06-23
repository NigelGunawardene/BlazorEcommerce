using BlazorEcommerce.Client.Interfaces;
using BlazorEcommerce.Client.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Client.Tests.Unit.Services;
public partial class VirtualizationServiceTests
{
    [Fact]
    public void ShouldSkipAndTakeOnLoadFirstPageFromDataSource()
    {
        //given
        int randomStartAt = GetRandomNumber();
        int randomPageSize = GetRandomNumber();
        int inputStartAt = randomStartAt;
        int inputPageSize = randomPageSize;
        IQueryable<object> randomQueryable = CreateRandomQueryable();

        IQueryable<object> returnedQueryable = randomQueryable;
        IQueryable<object> expectedQueryable = returnedQueryable;

        this.dataSourceBrokerMock.Setup(source =>
        source.TakeAndSkip(inputStartAt, inputPageSize)).Returns(returnedQueryable);

        // when
        IQueryable<object> actualQueryable = this.virtualizationService.LoadFirstPage(inputStartAt, inputPageSize);

        // then
        actualQueryable.Should().BeEquivalentTo(expectedQueryable);

        this.dataSourceBrokerMock.Verify(source =>
        source.TakeAndSkip(inputStartAt, inputPageSize), Times.Once);

        this.dataSourceBrokerMock.VerifyNoOtherCalls();

    }

}
