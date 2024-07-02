using System.Threading.Tasks;
using Microsoft.Playwright;

using static TestFramework.Support.Enums.FixturePaths;

using TestFramework.Support.pages;
using TestFramework.Support.Fixtures.Static;
using TestFramework.Support.Fixtures.Dynamic.Fakes;
using TestFramework.Support.Fixtures.Dynamic.Models;

namespace TestFramework.Tests.E2e.Authentication;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class ExampleTest : BasePage {
  public FixtureLoader? fix;
  private LoginPage _lp;
  private FakeBankAccount fakeBankAcc = new FakeBankAccount();

  [OneTimeSetUp]
  public void OneTimeSetup() {
    fix = new FixtureLoader([Users]);
    BankAccountModel bankAcc = fakeBankAcc.Generate();
  }

  [SetUp]
  public void Setup() {
    _lp = new LoginPage(Page);
  }

  [Test, Description("TC0001: Create a new ")]
  public async Task HasTitle() {

    Step("Go to Playwright page");
    await _lp.Open("/signin");
    await _lp.Fields.Username.FillAsync("asd123");
    //   await Page.GotoAsync("https://playwright.dev");
    //   await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

    // Console.WriteLine(fix!.Get(Users)!["customer"]!["email"]);
    // // Step("Expect true to eq false");
    // Assert.That(true, Is.EqualTo(false));
  }

  [Test]
  public async Task GetStartedLink() {
    await Page.GotoAsync("https://playwright.dev");

    // Click the get started link.
    await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

    // Expects page to have a heading with the name of Installation.
    await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
  }
}
