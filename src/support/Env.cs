using System;
using Microsoft.Extensions.Configuration;

namespace TestFramework.Support;

public static class Env
{
  private static IConfigurationRoot? env { get; set; }

  /// <summary>
  /// <para> Loads env vars for the test run with the following value precedence </para>
  /// <list type="number">
  /// <item><description> Values coming from process/cli environment </description></item>
  /// <item><description> Values coming playwright.env.json </description></item>
  /// <item><description> Values coming from fixture file (fixtures/{env}/config.json) </description></item>
  /// </list>
  /// </summary>
  public static void Load()
  {
    //Need to build first a temporary IConfigurationRoot to determine passed ENVIRONMENT
    IConfigurationRoot EnvWithoutFixtures = new ConfigurationBuilder()
      .AddJsonFile("playwright.env.json")
      .AddEnvironmentVariables("PLAYWRIGHT_")
      .Build();

    String environment = EnvWithoutFixtures.GetRequiredSection("ENVIRONMENT").Value;

    //With ENVIRONMENT now config from Fixtures can be included too
    Env.env = new ConfigurationBuilder()
      .AddJsonFile($"resources/fixtures/{environment}/config.json")
      .AddJsonFile("playwright.env.json")
      .AddEnvironmentVariables("PLAYWRIGHT_")
      .Build();
  }

  public static string? Get(string envVar)
  {
    try {
      return env!.GetRequiredSection(envVar).Value;
    } catch (InvalidOperationException e) {
      throw new NullReferenceException(
        $"Env var '{envVar}' not found. Was Env loaded correctly first?", e
      );
    } catch {
      throw;
    }
  }
}
