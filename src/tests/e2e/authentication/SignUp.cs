using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestFramework.Support.Fixtures.Dynamic.Fakes;
using TestFramework.Support.Fixtures.Dynamic.Models;
using TestFramework.Support.pages;

namespace TestFramework.Tests.E2e.Authentication;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class SignUp : BasePage
{
  private SignupPage SUP;
  private UserModel NewUser;

  [SetUp]
  public void Setup()
  {
    SUP = new SignupPage(Page);
    NewUser = new FakeUser().Generate("validInput");
  }

  [Test, Description("TC0001: Create a new user via Sign Up Page")]
  public async Task SignUpNewUserTest()
  {

    Step("Go to SignUp page -> Validate URL, title and element state");
    await SUP.Open("/signup");

    await Expect(Page).ToHaveURLAsync(new Regex("signup"));
    await Expect(Page).ToHaveTitleAsync(new Regex("Cypress Real World App"));
    await Expect(SUP.Buttons.Signup).ToBeDisabledAsync();
    await Expect(SUP.Links.GoToSignIn).ToBeVisibleAsync();
    await Expect(SUP.Links.GoToCypressDotIo).ToBeVisibleAsync();

    Step("Fill form with random Data -> Validate Signup button becomes enabled");
    await SUP.FillForm(NewUser);

    await Expect(SUP.Buttons.Signup).ToBeEnabledAsync();
  }
}
