using AccountDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ac = AccountDomain;

namespace AccountPersistenceDatabase.Configuration
{
    public class AccountConfiguration
    {
        public AccountConfiguration(EntityTypeBuilder<ac.Account> entityBuilder)
        {
            var accounts = new List<ac.Account>();
            var account1 = new ac.Account
            {
                AccountId = 1,
                AccountType = "Ahorros"
            };
            accounts.Add(account1);
            var account2 = new ac.Account
            {
                AccountId = 2,
                AccountType = "Ahorros"
            };
            accounts.Add(account2);

            entityBuilder.HasData(accounts);
        }
    }
}
