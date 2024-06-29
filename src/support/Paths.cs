using System;
using System.IO;
using static NUnit.Framework.TestContext;

namespace TestFramework.Support;

public static class Paths {
  public static string Pwd { get; } = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)!;
  public static string ScreenshotsFolder { get; } = Path.Combine(Paths.Pwd, "reports", "screenshots");
  public static string ScreenshotFile(TestAdapter testAdapter, bool fullPath = true) {
    string name = testAdapter.FullName + ".png";
    return fullPath? Path.Combine(Paths.ScreenshotsFolder, name) : name;
  }
}
