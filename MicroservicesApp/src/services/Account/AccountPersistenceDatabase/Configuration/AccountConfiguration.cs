using AccountDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountPersistenceDatabase.Configuration
{
    public class AccountConfiguration
    {
        public AccountConfiguration(EntityTypeBuilder<Account> entityBuilder)
        {
            var accounts = new List<Account>();
            var account1 = new Account
            {
                AccountId = 1,
                AccountType = "Ahorros"
            };
            accounts.Add(account1);
            var account2 = new Account
            {
                AccountId = 2,
                AccountType = "Ahorros"
            };
            accounts.Add(account2);

            entityBuilder.HasData(accounts);
        }
    }
}
