// /Helpers/BrowserHelper.cs
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

public class BrowserHelper : IAsyncDisposable
{
    private static IPlaywright _playwright;
    private static IBrowser _browser;
    private static bool _isInitialized = false;

    public static async Task InitializeAsync(bool headless = false)
    {
        if (!_isInitialized)
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
            _isInitialized = true;
        }
    }

    public static async Task<IBrowserContext> CreateNewContextAsync()
    {
        if (!_isInitialized)
        {
            throw new InvalidOperationException("BrowserHelper must be initialized before creating a context.");
        }
        return await _browser.NewContextAsync(new BrowserNewContextOptions { IgnoreHTTPSErrors = true });
    }

    public static async Task CloseAsync()
    {
        if (_browser != null)
        {
            await _browser.CloseAsync();
            _isInitialized = false;
        }

        if (_playwright != null)
        {
            _playwright.Dispose();
        }
    }

    public async ValueTask DisposeAsync() => await CloseAsync();

    public static async Task<IPage> CreateNewPageAsync()
    {
        var context = await CreateNewContextAsync();
        context.SetDefaultTimeout(10000); // 10 seconds
        context.SetDefaultNavigationTimeout(10000); // 10 seconds

        return await context.NewPageAsync();
    }

}
