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

    private static int GetRandomNumber() => new IntRange(min: 0, max: 10).GetValue();

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
