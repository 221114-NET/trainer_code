using BusinessLayer;
using ModelsLayer;
using RepoLayer;

namespace tests.api;

public class UnitTest1
{
    [Fact]
    public async Task Test1()
    {
        // we will MOCK (not MOQ, that's a testing applicaiton) the dependencies so that our unit tests test the MUT, NOT the dependency.

        // Arrange - create the enviromnent
        IRepositoryClass i = new MockRepoLayer();
        BusinessLayerClass bl = new BusinessLayerClass(i);

        //ACT
        List<Customer> list = await bl.GetCustomerListAsync();

        //Assert
        Assert.Equal(list[0].FirstName, "m1");

    }
}