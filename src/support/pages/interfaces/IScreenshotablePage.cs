using System.Threading.Tasks;
using Microsoft.Playwright;

namespace TestFramework.Support.pages.interfaces;

public interface IScreenshotablePage {
  IPage Page {get; set;}
  public async Task SaveScreenshot(string path) {
    await Page.ScreenshotAsync(new() { Path = path });
  }
}
