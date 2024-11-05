// /Pages/LoginPage.cs
using Microsoft.Playwright;
using SITS_Test_Automation.Tests.UITest.Interfaces;

public class LoginPage : ILoginPage
{

    private readonly string usernameEmail = "input[name='username']";
    private readonly string usernameField = "input[name='UserName']";
    private readonly string passwordField = "input[name='Password']";
    private readonly string nextButton = "button[type='submit']";
    private readonly string submitButton = "//*[@id='submitButton']";


    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task NavigateToUrl(string url)
    {
        await _page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
    }

    public async Task EnterUserEmail(string email)
    {
        await _page.FillAsync(usernameEmail, email);
        await _page.ClickAsync(nextButton);
    }

    public async Task EnterUsername(string username)
    {
        await _page.FillAsync(usernameField, username);
    }

    public async Task EnterPassword(string password)
    {
        await _page.FillAsync(passwordField, password);
        await _page.ClickAsync(submitButton);
    }

}
