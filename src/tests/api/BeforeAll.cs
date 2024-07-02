using System;

namespace TestFramework.Tests.Api;

[SetUpFixture]
public class BeforeAll {
  [OneTimeSetUp]
  public void RunBeforeAnyTests() {
    // ...
  }

  [OneTimeTearDown]
  public void RunAfterAnyTests() {
    // ...
  }
}
