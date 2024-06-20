using Microsoft.Playwright;

namespace testFramework.support.abstracts;

public abstract class Locators(IPage page) {
    protected IPage _page = page;
}
