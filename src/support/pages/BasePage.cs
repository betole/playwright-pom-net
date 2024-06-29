using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework.Interfaces;

using TestFramework.Support.pages.interfaces;
using TestFramework.Support.pages;

using static TestFramework.Support.Paths;

namespace TestFramework.Support.pages;

public class BasePage: PageTest, IScreenshotablePage {
  public new IPage Page {get; set;}
  private string? StepDescription;
  public delegate void StepDelegate();
  public void Step(string description) {
    if (this.StepDescription != null) {
      this.StepDescription += " \u2713";
      Console.WriteLine(this.StepDescription);
      this.StepDescription = description;
    }
  }

  [SetUp]
  public async Task InitPage() {
    this.Page = await base.Context.NewPageAsync().ConfigureAwait(continueOnCapturedContext: false);
  }

  [TearDown]
  public async Task TearDownSaveScreenshot() {
    if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure) {
      await ((IScreenshotablePage)this).SaveScreenshot(ScreenshotFile(TestContext.CurrentContext.Test));
    }
  }
}
