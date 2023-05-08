using TestingSupport.PlaywrightHelpers.Common;

namespace SpecflowParallel.Pages;

public class SignInPage : PageBase
{
    public SignInPage(IPage page)
    {
        Page = page;
    }

    public override bool OnPage => Page.Url.ToLower().Contains("/signin?");

    public By UsernameTextbox => By.Id("user-identifier-input");

    public By PasswordTextbox => By.Id("password-input");

    public By SignInButton => By.Id("submit-button");
}