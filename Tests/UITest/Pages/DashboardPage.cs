// /Pages/DashboardPage.cs
using Microsoft.Playwright;
using SITS_Test_Automation.Tests.UITest.Interfaces;
using System.Threading.Tasks;

public class DashboardPage : IDashboardPage
{
    private readonly IPage _page;

    public DashboardPage(IPage page)
    {
        _page = page;
    }

    public async Task<string> GetTitleAsync()
    {
        return await _page.TitleAsync();
    }
}
