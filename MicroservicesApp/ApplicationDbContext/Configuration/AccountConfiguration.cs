using AccountDomain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountPersistenceDatabase.Configuration
{
    public class AccountConfiguration
    {
        public ClientConfiguration(EntityTypeBuilder<Account> entityBuilder)
        {
            var account = new Account
            {
                AccountId = 1,
                AccountNumber = ""
            }
        }
    }
