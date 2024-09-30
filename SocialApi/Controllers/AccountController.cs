using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;

namespace SocialApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        //show all
        // GET: api/Account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccount()
        {
            var acc = await _accountRepository.GetAccountsAsync();
            if (acc == null || !acc.Any())
            {
                return BadRequest();
            }
            return Ok(acc);
        }

        // GET: api/acc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountById(string id)
        {

            var Account = await _accountRepository.GetAccountByIdAsync(id);
            if (Account == null)
            {
                return BadRequest();
            }
            return Ok(Account);
        }

        // PUT: api/acc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(string id, Account Account)
        {
            if (id != Account.Id)
            {
                return BadRequest();
            }

            try
            {
                await _accountRepository.UpdateAccountAsync(Account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AccountExists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/acc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account Account)
        {

            await _accountRepository.SaveAccountAsync(Account);
            return CreatedAtAction(nameof(GetAccount), new { id = Account.Id }, Account);
        }

        // DELETE: api/acc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var Account = await _accountRepository.GetAccountByIdAsync(id);
            if (Account == null)
            {
                return BadRequest();
            }

            await _accountRepository.DeleteAccountAsync(Account);
            return NoContent();
        }

        private async Task<bool> AccountExists(string id)
        {
            var Account = await _accountRepository.GetAccountByIdAsync(id);
            return Account != null;
        }
    }
}

