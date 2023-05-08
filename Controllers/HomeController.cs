using SpecflowParallel.Pages;

namespace SpecflowParallel.Controllers;

public class HomeController : ControllerBase
{
    public HomePage HomePage { get; }
    private readonly SignInPage _signinPage;

    public HomeController(IPage page)
    {
        Page = page;
        HomePage = new HomePage(page);
        _signinPage = new SignInPage(page);
    }

    public async Task Login(string username, string password)
    {
        if (!HomePage.OnPage)
        {
            await HomePage.NavigateAsync();
        }

        await HomePage.SignInButton.ClickAsync();

        await Page.TypeAsync(_signinPage.UsernameTextbox.Locator, username);
        await Page.TypeAsync(_signinPage.PasswordTextbox.Locator, password);

        // await Task.WhenAll(usernameTask, passwordTask);

        await Page.ClickAsync(_signinPage.SignInButton.Locator);
    }
}