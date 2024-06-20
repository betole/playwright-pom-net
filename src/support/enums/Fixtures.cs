namespace testFramework.support.enums;

public class Fixtures {
  public string Filename { get; }
  public bool IsEnvSpecific { get; }

  public readonly static Fixtures Users = new("users.json", true);
  public readonly static Fixtures Urls = new("urls.json", true);
  public readonly static Fixtures Endpoints = new("endpoints.json", false);

  Fixtures(string filename, bool isEnvSpecific) {
    this.Filename = filename;
    this.IsEnvSpecific = isEnvSpecific;
  }
}
