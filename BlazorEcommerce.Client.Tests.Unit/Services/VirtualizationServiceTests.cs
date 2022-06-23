using BlazorEcommerce.Client.Brokers.DataSources;
using BlazorEcommerce.Client.Interfaces;
using BlazorEcommerce.Client.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;


// we used xUnit template, nuget dependences are tynamix.objectfiller and fluentassertions so we can check values without references
// First we tried to use IQueryable<object> but it didnt work, so we wrapped the IQueryable behind a contract. This is what IDataSourceBroker does. Brokers dont need unit tests because their purpose is to wrap what we cannot unit test because its out of scope. they should be very thin and only communicate with the outside world
// Broker is under our control and we can test only what the broker is doing. we focus on what our service can control or owns vs anything else

namespace BlazorEcommerce.Client.Tests.Unit.Services;
public partial class VirtualizationServiceTests
{
    private readonly Mock<IDataSourceBroker<object>> dataSourceBrokerMock;
    private readonly IVirtualizationService<object> virtualizationService;

    public VirtualizationServiceTests()
    {
        dataSourceBrokerMock = new Mock<IDataSourceBroker<object>>();

        virtualizationService = new VirtualizationService<object>(_dataSourceBroker: dataSourceBrokerMock.Object);
    }

    private static uint GetRandomPositiveNumber() => (uint)new IntRange(min: 0, max: 10).GetValue();

    private static string GetRandomMessage() => new MnemonicString().GetValue();

    public static IQueryable<object> CreateRandomQueryable() => CreateQueryableFiller().Create().AsQueryable();

    private static object CreateRandomObject()
    {
        return new MnemonicString().GetValue();
    }

    public static Filler<List<object>> CreateQueryableFiller()
    {
        var filler = new Filler<List<object>>();
        filler.Setup().OnType<object>().Use(CreateRandomObject());

        return filler;
    }
}
