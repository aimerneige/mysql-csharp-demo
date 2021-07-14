using System;
using mysql_csharp_demo.Model;
using Microsoft.EntityFrameworkCore;

namespace mysql_csharp_demo.Database.Context
{
    public class AccountContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }

        public AccountContext(DbContextOptions options) : base(options)
        {
        }
    }
}
