namespace TestFramework.Support.Enums;

public class PrivacyLevels(string level)
{
  public string Level => level;
  public readonly static PrivacyLevels Public = new("public");
  public readonly static PrivacyLevels Private = new("private");
  public readonly static PrivacyLevels Contacts = new("contacts");
  public readonly static PrivacyLevels[] All = [Public, Private, Contacts];
}
