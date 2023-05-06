using Microsoft.Extensions.Configuration;
using SpecflowParallel.Helpers;
using TestingSupport.Common.Utilities;

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

        StaticData.TestConfig = StaticData.Configuration.Get<TestConfig>();
        
        TestRunHelper.SetupTestRun();

        LoggingHelper.LogDirectory = StaticData.TestRunDirectory;
    }

    [OneTimeTearDown]
    public void AssemblyTeardown()
    {
        
    }
}