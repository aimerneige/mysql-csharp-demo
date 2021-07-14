using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using mysql_csharp_demo.Model;
using mysql_csharp_demo.Database.Context;
using mysql_csharp_demo.Database.Provider;

namespace mysql_csharp_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountContext accountContext;
        private readonly AccountProvider accountProvider;

        public AccountController(AccountContext _context)
        {
            this.accountContext = _context;
            this.accountProvider = new AccountProvider(accountContext);
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Account>> GetAll() =>
            accountProvider.GetAllAccounts().ToList();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Account> Get(int id)
        {
            var account = accountProvider.GetAccountWithId(id);

            if (account == null)
                return NotFound();

            return account;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Account account)
        {
            // This code will save the account and return a result
            accountProvider.InsertAccount(account);
            return CreatedAtAction(nameof(Create), new { id = account.Id }, account);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Account account)
        {
            // This code will update the account and return a result
            if (id != account.Id)
                return BadRequest();

            var existingAccount = accountProvider.GetAccountWithId(id);
            if(existingAccount is null)
                return NotFound();

            accountProvider.UpdateAccount(id, account);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // This code will delete the account and return a result
            var account = accountProvider.GetAccountWithId(id);

            if (account is null)
                return NotFound();

            accountProvider.DeleteAccountWithId(id);

            return NoContent();
        }
    }
}
