using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Collections.Generic;

using TestFramework.Support.Enums;

namespace TestFramework.Support.Fixtures.Static;

public class FixtureLoader {
  private readonly string pwd = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)!;

  private Dictionary<FixturePaths, JsonNode> fixtures = [];

  private JsonNode ReadJsonNode(FixturePaths fixture, string env) {
    string jsonString = File.ReadAllText(
      Path.Combine(
        this.pwd,
        "resources",
        "fixtures",
        fixture.IsEnvSpecific ? env : "common",
        fixture.Filename
    ));
    JsonNode node = JsonNode.Parse(jsonString)!;
    return node;
  }

  private void Load(FixturePaths[] fixtures) {
    string? env = Env.Get("ENVIRONMENT");
    if (env is null) {
      throw new KeyNotFoundException("Can't load fixtures: 'ENVIRONMENT' not found.");
    }
    foreach (FixturePaths fixture in fixtures) {
      this.fixtures!.Add(fixture, this.ReadJsonNode(fixture, env));
    }
  }

  public FixtureLoader(FixturePaths[] fixtures) {
    this.Load(fixtures);
  }

  public JsonNode Get(FixturePaths fixture) {
    return this.fixtures![fixture];
  }
}
