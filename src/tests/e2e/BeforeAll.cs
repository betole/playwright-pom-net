using System;

namespace TestFramework.Tests.E2e;

[SetUpFixture]
public class BeforeAll
{
  [OneTimeSetUp]
  public void RunBeforeAnyTests()
  {
    // ...
  }

  [OneTimeTearDown]
  public void RunAfterAnyTests()
  {
    // ...
  }
}
