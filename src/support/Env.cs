using System;
using Microsoft.Extensions.Configuration;

namespace TestFramework.Support;

public static class Env
{
  private static IConfigurationRoot? env { get; set; }

  public static void Load()
  {
    Env.env = new ConfigurationBuilder()
      .AddJsonFile("playwright.env.json")
      .Build();
  }

  public static string? Get(string envVar)
  {
    if (Env.env is null)
    {
      throw new NullReferenceException("Env object has not been loaded from JSON");
    }
    IConfigurationSection section = Env.env.GetRequiredSection(envVar);
    return section.Value;
  }
}
