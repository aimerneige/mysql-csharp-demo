using System;
using System.Linq;
using mysql_csharp_demo.Model;
using mysql_csharp_demo.Database.Context;

namespace mysql_csharp_demo.Database.Provider
{
    public class AccountProvider
    {
        private readonly AccountContext dbContext;

        public AccountProvider(AccountContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertAccount(Account account)
        {
            dbContext.Add(account);
            dbContext.SaveChanges();
        }

        public IOrderedQueryable<Account> GetAllAccounts()
        {
            return dbContext.Accounts.OrderBy(t => t.Id);
        }

        public Account GetAccountWithId(int id)
        {
            return dbContext.Accounts.Where(t => t.Id == id).FirstOrDefault();
        }

        public void DeleteAccountWithId(int id)
        {
            dbContext.Accounts.Remove(GetAccountWithId(id));
            dbContext.SaveChanges();
        }

        public void UpdateAccount(int id, Account newAccount)
        {
            var account = GetAccountWithId(id);
            Account.CopyProp(account, newAccount);
            dbContext.SaveChanges();
        }
    }
}
