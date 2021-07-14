using System;

namespace mysql_csharp_demo.Model
{
    public class Account
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public static void CopyProp(Account a, Account b)
        {
            a.Name = b.Name;
            a.Password = b.Password;
        }
    }
}
