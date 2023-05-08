using Microsoft.Playwright;

namespace SpecflowParallel.Lifecycle;

[Binding]
public class ScenarioLifecycle
{
    private readonly ScenarioContext _scenarioContext;

    public ScenarioLifecycle(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario(Order = 0)]
    public async Task BeforeScenario()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = StaticData.TestConfig.Headless,
            Channel = "chrome"
        });

        var authData = Path.Combine(StaticData.TestRunDirectory, "authdata.json");
        var options = new BrowserNewContextOptions();

        if (File.Exists(authData))
        {
            options.StorageState = authData;
        }
        
        var context = await browser.NewContextAsync(options);
        
        _scenarioContext.ScenarioContainer.RegisterInstanceAs(context);

        var page = await context.NewPageAsync();

        await page.GotoAsync(StaticData.TestConfig.SiteUrl);
        
        _scenarioContext.ScenarioContainer.RegisterInstanceAs(page);
    }

    [AfterScenario()]
    public async Task TeardownScenarios()
    {
        var context = _scenarioContext.ScenarioContainer.Resolve<IBrowserContext>();

        if (context != null)
        {
            await context.DisposeAsync();
        }
    }
}