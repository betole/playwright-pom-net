using Microsoft.Playwright;

namespace TestFramework.Support.abstracts;

public abstract class Actions(IPage page) {
  protected IPage _page = page;
}
