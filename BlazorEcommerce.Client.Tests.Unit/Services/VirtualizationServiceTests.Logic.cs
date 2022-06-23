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
        uint randomStartAt = GetRandomPositiveNumber();
        uint randomPageSize = GetRandomPositiveNumber();
        uint inputStartAt = randomStartAt;
        uint inputPageSize = randomPageSize;
        IQueryable<object> randomQueryable = CreateRandomQueryable();

        IQueryable<object> returnedQueryable = randomQueryable;
        IQueryable<object> expectedQueryable = returnedQueryable;

        this.dataSourceBrokerMock.Setup(source =>
        source.TakeSkip(inputStartAt, inputPageSize)).Returns(returnedQueryable);

        // when
        IQueryable<object> actualQueryable = this.virtualizationService.LoadFirstPage(inputStartAt, inputPageSize);

        // then
        actualQueryable.Should().BeEquivalentTo(expectedQueryable);

        this.dataSourceBrokerMock.Verify(source =>
        source.TakeSkip(inputStartAt, inputPageSize), Times.Once);

        this.dataSourceBrokerMock.VerifyNoOtherCalls();

    }

}
