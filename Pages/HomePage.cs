namespace SpecflowParallel.Pages;

public class HomePage : PageBase
{
    public HomePage(IPage page)
    {
        Page = page;
    }

    public override bool OnPage => Page.TitleAsync().Result.ToLower().Contains("bbc - home");

    public ILocator SignInButton => Page.GetByText("Sign in");

    public async Task NavigateAsync()
    {
        if (OnPage)
        {
            return;
        }
        await Page.GotoAsync(StaticData.TestConfig.SiteUrl);
    }
}