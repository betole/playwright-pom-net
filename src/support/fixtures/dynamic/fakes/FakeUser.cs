using System;
using Bogus;
using TestFramework.Support.Enums;
using TestFramework.Support.Fixtures.Dynamic.Models;

namespace TestFramework.Support.Fixtures.Dynamic.Fakes;

public class FakeUser : Faker<UserModel> {
  public int Seed { get; private set; }

  private void ValidInputRuleSet() {
    RuleSet("validInput", set => {
      set
      .RuleFor(user => user.FirstName, bogus => bogus.Name.FirstName())
      .RuleFor(user => user.LastName, bogus => bogus.Name.LastName())
      .RuleFor(user => user.Email, (bogus, user) => bogus.Internet.Email(user.FirstName, user.LastName))
      .RuleFor(user => user.UserName, bogus => bogus.Internet.UserName())
      .RuleFor(user => user.Password, bogus => bogus.Internet.Password());
    });
  }

  private void ApiMockRuleSet(PrivacyLevels? privacyLevel) {
    RuleSet("apiMock", set => {
      set
        .RuleFor(user => user.FirstName, bogus => bogus.Name.FirstName())
        .RuleFor(user => user.LastName, bogus => bogus.Name.LastName())
        .RuleFor(user => user.Email, (bogus, user) => bogus.Internet.Email(user.FirstName, user.LastName))
        .RuleFor(user => user.UserName, bogus => bogus.Internet.UserName())
        .RuleFor(user => user.Password, bogus => bogus.Internet.Password())
        .RuleFor(user => user.PhoneNumber, bogus => bogus.Phone.PhoneNumberFormat())
        .RuleFor(user => user.Avatar, bogus => bogus.Internet.Avatar().OrNull(bogus))
        .RuleFor(user => user.Balance, bogus => (float)bogus.Finance.Amount(-500, 10000))
        .RuleFor(user => user.PrivacyLevel, bogus => privacyLevel != null ? privacyLevel.Level : bogus.PickRandom<PrivacyLevels>(PrivacyLevels.All).Level);
    });
  }

  public FakeUser(int? seed = null, PrivacyLevels? privacyLevel = null) {
    Seed = seed ?? new Random().Next(0, 10000);
    UseSeed(Seed);
    ValidInputRuleSet();
    ApiMockRuleSet(privacyLevel);
  }
}
