// /Helpers/TestLifecycleHelper.cs
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

public class TestLifecycleHelper
{
    private IPage _page;
    private readonly string _screenshotPath = "TestResults/Screenshots";

    public async Task<IPage> InitializeTestAsync()
    {
        await BrowserHelper.InitializeAsync();
        _page = await BrowserHelper.CreateNewPageAsync();

        // Ensure the screenshots directory exists
        Directory.CreateDirectory(_screenshotPath);

        return _page;
    }

    public async Task CleanupTestAsync(TestContext context)
    {
        if (context.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var screenshotFileName = $"{_screenshotPath}/{context.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotFileName });
            TestContext.AddTestAttachment(screenshotFileName, "Screenshot on Failure");
        }

        if (_page != null)
        {
            await _page.CloseAsync();
        }
    }

    public async Task FinalCleanupAsync() => await BrowserHelper.CloseAsync();
}
