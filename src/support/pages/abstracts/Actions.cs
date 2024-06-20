using Microsoft.Playwright;

namespace testFramework.support.abstracts;

public abstract class Actions(IPage page) {
    protected IPage _page = page;
}
