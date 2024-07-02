using Microsoft.Playwright;

namespace TestFramework.Support.abstracts;

public abstract class Locators(IPage page) {
  protected IPage _page = page;
}
