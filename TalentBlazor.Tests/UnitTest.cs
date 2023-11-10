using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using TalentBlazor.ServiceInterface;
using TalentBlazor.ServiceModel;

namespace TalentBlazor.Tests;

public class UnitTest
{
    private readonly ServiceStackHost appHost;

    public UnitTest()
    {
        Licensing.RegisterLicense("OSS MIT 2023 https://github.com/NetCoreApps/TalentBlazorServer NdCmSFOfRpijw7CNjO4WXv4gYzeHjYSOaFRVlbp5rezlsB1FtDHUA34hYsJDMbxWDMiXqG29DPzPvJb6oXqLqkdCISRKOhhjZKb1KleG67PaHj9B2E/s65m9mB7Okq3uUHJzxpkn/3M0lvI4qL6Gb6jfmrx0+N0QxYsY41rjQpo=");
        appHost = new BasicAppHost().Init();
        appHost.Container.AddTransient<MyServices>();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => appHost.Dispose();

    [Test]
    public void Can_call_MyServices()
    {
        var service = appHost.Container.Resolve<MyServices>();

        var response = (HelloResponse)service.Any(new Hello { Name = "World" });

        Assert.That(response.Result, Is.EqualTo("Hello, World!"));
    }
}