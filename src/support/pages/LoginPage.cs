using System.Threading.Tasks;
using Microsoft.Playwright;

using testFramework.support.abstracts;

namespace testFramework.support.pages;

public sealed class LoginPage {
  private readonly IPage _page;
  public FieldLocators Fields {get; private set;}
  public ButtonLocators Buttons {get; private set;}
  public LinkLocators Links {get; private set;}
  public LabelLocators Labels {get; private set;}
  public ContainerLocators Containers {get; private set;}
  public CheckboxLocators Checkboxes {get; private set;}
  public AlertLocators Alerts {get; private set;}
  
  public LoginPage(IPage page) {
    _page = page; 
    Fields = new FieldLocators(_page);
    Buttons = new ButtonLocators(_page);
    Links = new LinkLocators(_page);
    Labels = new LabelLocators(_page);
    Containers = new ContainerLocators(_page);
    Checkboxes = new CheckboxLocators(_page);
    Alerts = new AlertLocators(_page);
  }

  #region locators
  public sealed class FieldLocators(IPage page) : Locators(page) {
    public ILocator Username => _page.Locator("#username");
    public ILocator Password => _page.Locator("#password");
  }

  public sealed class LabelLocators(IPage page) : Locators(page) {
    public ILocator HeaderTitle => _page.Locator("[data-test='signup-title']");
    public ILocator FirstNameRequired => _page.Locator("#firstName-helper-text");
    public ILocator LastNameRequired => _page.Locator("#lastName-helper-text");
    public ILocator UserNameRequired => _page.Locator("#username-helper-text");
    public ILocator PasswordRequired => _page.Locator("#password-helper-text");
    public ILocator ConfirmPasswordRequired => _page.Locator("#confirmPassword-helper-text");
  }

  public sealed class ButtonLocators(IPage page) : Locators(page) {
    public ILocator SignIn => _page.Locator("[data-test='signin-submit']");
  }

  public sealed class ContainerLocators(IPage page) : Locators(page) {
    public ILocator Root => _page.Locator("#root");
  }
  
  public sealed class LinkLocators(IPage page) : Locators(page) {
    public ILocator GoToSignUp => _page.Locator("a[href='/signup']");
    public ILocator GoToCypressDotIo => _page.Locator("a[href='https://cypress.io']");
  }

  public sealed class CheckboxLocators(IPage page) : Locators(page) {
    public ILocator RememberMe => _page.Locator("[data-test='signin-remember-me'] input");
  }

  public sealed class AlertLocators(IPage page) : Locators(page) {
    public ILocator SigninError => _page.Locator("[data-test='signin-error']");
  }
  #endregion

  #region actions
  private async Task _fillField(ILocator field, string value, bool clickFirst = true) {
    if (clickFirst) await field.ClickAsync();
    await field.FillAsync(value);
  }

  public async Task Open(string page) => await _page.GotoAsync(page);

  public async Task FillForm(
    string? userName,
    string? password
  ) {
    if (userName != null) await _fillField(Fields.Username, userName);
    if (password != null) await _fillField(Fields.Password, password);
  }

  public async Task GoToSignUp() => await Links.GoToSignUp.ClickAsync();

  public async Task GoToCypressDotIo() => await Links.GoToCypressDotIo.ClickAsync();

  #endregion
}
