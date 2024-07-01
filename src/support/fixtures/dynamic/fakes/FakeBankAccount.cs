using System;
using Bogus;

using TestFramework.Support.Basic;
using TestFramework.Support.Fixtures.Dynamic.Models;

namespace TestFramework.Support.Fixtures.Dynamic.Fakes;

public class FakeBankAccount: Faker<BankAccountModel> {
    public int Seed { get; private set; }

    private void ValidInputRuleSet() {
    RuleSet("validInput", set => {
      set
        .RuleFor(acc => acc.AccountNumber, bogus => bogus.Finance.Account())
        .RuleFor(acc => acc.RoutingNumber, bogus => bogus.Finance.RoutingNumber())
        .RuleFor(acc => acc.BankName, bogus => bogus.Company.CompanyName(BogusPatterns.GenericCompanyName));
      });
    }

    private void ApiMockRuleSet(bool? isDeleted) {
    RuleSet("apiMock", set => {
      set
        .RuleFor(acc => acc.AccountNumber, bogus => bogus.Finance.Account())
        .RuleFor(acc => acc.RoutingNumber, bogus => bogus.Finance.RoutingNumber())
        .RuleFor(acc => acc.BankName, bogus => bogus.Company.CompanyName(BogusPatterns.GenericCompanyName))
        .RuleFor(acc => acc.IsDeleted, bogus => isDeleted?? bogus.Random.Bool())
        .RuleFor(acc => acc.Id, bogus => bogus.Random.String2(11, BogusPatterns.AlphaNumeric))
        .RuleFor(acc => acc.Uuid, bogus => bogus.Random.Uuid().ToString())
        .RuleFor(acc => acc.UserId, bogus => bogus.Random.String2(9, BogusPatterns.AlphaNumeric))
        .RuleFor(acc => acc.CreatedAt, bogus => bogus.Date.PastDateOnly().ToString())
        .RuleFor(acc => acc.ModifiedAt, (bogus, acc) => bogus.Date.PastDateOnly(refDate: DateOnly.Parse(acc.CreatedAt)).ToString());
      });
    }


    public FakeBankAccount(int? seed = null, bool? isDeleted = null) {
        Seed = seed?? new Random().Next(0, 10000);
        Random rng = new Random(Seed);
        UseSeed(Seed);
        ValidInputRuleSet();
        ApiMockRuleSet(isDeleted);
    }
}
