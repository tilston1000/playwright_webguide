using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;

namespace PlaywrightTests;

[TestClass]
public class ExampleTest : PageTest
{
    [TestInitialize]
    public async Task TestInitialize()
    {
        await Page.GotoAsync("https://playwright.dev");
        var userAgent = await Page.EvaluateAsync<string>("() => navigator.userAgent");
        TestContext?.WriteLine($"UserAgent: {userAgent}");
    }

    [TestMethod]
    public async Task HasTitle()
    {
        // Expect a title "to contain" a substring
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
    }

    [TestMethod]
    public async Task GetStartedLink()
    {
        // Click the get started link
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        // Expects page to have a heading with the name of Installation
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation"})).ToBeVisibleAsync();
    }
}
