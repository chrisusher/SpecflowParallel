using SpecflowParallel.Controllers;

namespace SpecflowParallel.Steps;

[Binding]
public class BBCSteps : StepsBase
{
    private readonly HomeController _homeController;

    public BBCSteps(FeatureContext featureContext, ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _featureContext = featureContext;
        Page = _scenarioContext.ScenarioContainer.Resolve<IPage>();
        
        _homeController = new HomeController(Page);
    }
    
    #region Given Methods

    [Given("The Home Page is Loaded")]
    public async Task GivenHomePageIsLoaded()
    {
        await _homeController.HomePage.NavigateAsync();
    }
    
    #endregion

    #region When Methods

    [When("I Sign In to my Account")]
    public async Task WhenISignToMyAccount()
    {
        await _homeController.HomePage.NavigateAsync();
        await _homeController.HomePage.SignInButton.ClickAsync();
    }

    [When("I enter correct Credentials")]
    public async Task WhenIEnterCorrectCredentials()
    {
        await _homeController.Login(StaticData.Configuration["BBC_USERNAME"], StaticData.Configuration["BBC_PASSWORD"]);
    }

    #endregion

    #region Then Methods

    [Then("I am logged in")]
    public async Task ThenIAmLoggedIn()
    {
        Assert.IsTrue(await Page.GetByText("Welcome to the BBC").IsVisibleAsync(), "Welcome to the BBC was not visible.");
    }

    #endregion
}