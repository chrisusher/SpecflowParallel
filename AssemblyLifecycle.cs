using Microsoft.Extensions.Configuration;
using SpecflowParallel.Helpers;

namespace SpecflowParallel;

[SetUpFixture]
public class AssemblyLifecycle
{
    [OneTimeSetUp]
    public void AssemblySetup()
    {
        StaticData.Configuration = new ConfigurationBuilder()
            .AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
            .Build();
        
        TestRunHelper.SetupTestRun();
    }

    [OneTimeTearDown]
    public void AssemblyTeardown()
    {
        
    }
}