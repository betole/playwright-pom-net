using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Collections.Generic;

using testFramework.support.enums;

namespace testFramework.support;

public class Fixture {
    private readonly string pwd = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)!;

    private Dictionary<Fixtures, JsonNode> fixtures = [];

    private JsonNode ReadJsonNode(Fixtures fixture, string env) {
      string jsonString = File.ReadAllText(
        Path.Combine(
          this.pwd, 
          "resources", 
          "fixtures", 
          fixture.IsEnvSpecific? env : "common", 
          fixture.Filename
      ));
      JsonNode node = JsonNode.Parse(jsonString)!;
      return node;
    }

    private void Load(Fixtures[] fixtures) {
        string? env = Env.Get("ENVIRONMENT");
        if (env is null) {
          throw new KeyNotFoundException("Can't load fixtures: 'ENVIRONMENT' not found.");
        }
        foreach (Fixtures fixture in fixtures) {
            this.fixtures!.Add(fixture, this.ReadJsonNode(fixture, env));
        }
    }

    public Fixture(Fixtures[] fixtures) {
        this.Load(fixtures);
    }

    public JsonNode Get(Fixtures fixture) {
        return this.fixtures![fixture];
    }
}
