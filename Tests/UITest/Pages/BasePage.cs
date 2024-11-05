using Microsoft.Playwright;

public class BasePage
{
    protected readonly IPage _page;

    public BasePage(IPage page)
    {
        _page = page;
    }

    public async Task NavigateToUrl(string url)
    {
        await _page.GotoAsync(url);
    }

    public async Task<string> GetPageTitleAsync()
    {
        return await _page.TitleAsync();
    }

}
