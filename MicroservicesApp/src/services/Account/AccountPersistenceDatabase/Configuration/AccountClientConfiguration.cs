using AccountDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountPersistenceDatabase.Configuration
{
    public class AccountClientConfiguration
    {
        public AccountClientConfiguration(EntityTypeBuilder<AccountClient> entityBuilder)
        {
            var accounts = new List<AccountClient>();
            var account1 = new AccountClient
            {
                AccountId = 2,
                AccountClientId = 1,
                AccountNumber = "478758",
                Balance = 2000,
                ClientId = 1,
                State = true
            };
            accounts.Add(account1);
            var account2 = new AccountClient
            {
                AccountId = 1,
                AccountClientId = 2,
                AccountNumber = "225487 ",
                Balance = 100,
                ClientId = 3,
                State = true
            };
            accounts.Add(account2);

            entityBuilder.HasData(accounts);
        }
    }
}
