namespace TestFramework.Support.Enums;

public class FixturePaths {
  public string Filename { get; }
  public bool IsEnvSpecific { get; }

  public readonly static FixturePaths Users = new("users.json", true);
  public readonly static FixturePaths Urls = new("urls.json", true);
  public readonly static FixturePaths Endpoints = new("endpoints.json", false);

  public readonly static FixturePaths[] All = [Users, Urls, Endpoints];

  FixturePaths(string filename, bool isEnvSpecific) {
    this.Filename = filename;
    this.IsEnvSpecific = isEnvSpecific;
  }
}
