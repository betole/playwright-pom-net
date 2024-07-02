using TestFramework.Support;

namespace TestFramework.Tests.E2e;

[SetUpFixture]
public class BeforeAll {
  [OneTimeSetUp]
  public void RunBeforeAnyTests() {
    Env.Load();
  }

  [OneTimeTearDown]
  public void RunAfterAnyTests() {
    // ...
  }
}
