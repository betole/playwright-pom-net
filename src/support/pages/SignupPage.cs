using System.Threading.Tasks;
using Microsoft.Playwright;

using TestFramework.Support.abstracts;

namespace TestFramework.Support.pages;

public sealed class SignupPage
{
  private readonly IPage _page;
  public FieldLocators Fields { get; private set; }
  public ButtonLocators Buttons { get; private set; }
  public LinkLocators Links { get; private set; }
  public LabelLocators Labels { get; private set; }
  public ContainerLocators Containers { get; private set; }

  public SignupPage(IPage page)
  {
    _page = page;
    Fields = new FieldLocators(_page);
    Buttons = new ButtonLocators(_page);
    Links = new LinkLocators(_page);
    Labels = new LabelLocators(_page);
    Containers = new ContainerLocators(_page);
  }

  #region locators
  public sealed class FieldLocators(IPage page) : Locators(page)
  {
    public ILocator FirstName => _page.Locator("#firstName");
    public ILocator LastName => _page.Locator("#lastName");
    public ILocator Username => _page.Locator("#username");
    public ILocator Password => _page.Locator("#password");
    public ILocator ConfirmPassword => _page.Locator("#confirmPassword");
  }

  public sealed class LabelLocators(IPage page) : Locators(page)
  {
    public ILocator HeaderTitle => _page.Locator("[data-test='signup-title']");
    public ILocator FirstNameRequired => _page.Locator("#firstName-helper-text");
    public ILocator LastNameRequired => _page.Locator("#lastName-helper-text");
    public ILocator UserNameRequired => _page.Locator("#username-helper-text");
    public ILocator PasswordRequired => _page.Locator("#password-helper-text");
    public ILocator ConfirmPasswordRequired => _page.Locator("#confirmPassword-helper-text");
  }

  public sealed class ButtonLocators(IPage page) : Locators(page)
  {
    public ILocator Signup => _page.Locator("[data-test='signup-submit']");
  }

  public sealed class ContainerLocators(IPage page) : Locators(page)
  {
    public ILocator Root => _page.Locator("#root");
  }

  public sealed class LinkLocators(IPage page) : Locators(page)
  {
    public ILocator GoToSignIn => _page.Locator("a[href='/signin']");
    public ILocator GoToCypressDotIo => _page.Locator("a[href='https://cypress.io']");
  }
  #endregion

  #region actions
  private async Task _fillField(ILocator field, string value, bool clickFirst = true)
  {
    if (clickFirst) await field.ClickAsync();
    await field.FillAsync(value);
  }

  public async Task Open(string page) => await _page.GotoAsync(page);

  public async Task FillForm(
    string? firstName,
    string? lastName,
    string? userName,
    string? password,
    string? confirmPassword
  )
  {
    if (firstName != null) await _fillField(Fields.FirstName, firstName);
    if (lastName != null) await _fillField(Fields.LastName, lastName);
    if (userName != null) await _fillField(Fields.Username, userName);
    if (password != null) await _fillField(Fields.Password, password);
    if (confirmPassword != null) await _fillField(Fields.ConfirmPassword, confirmPassword);
  }

  public async Task GoToSignIn() => await Links.GoToSignIn.ClickAsync();

  public async Task GoToCypressDotIo() => await Links.GoToCypressDotIo.ClickAsync();

  #endregion
}
