using BussinessObject;
using DataAccess;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public async Task DeleteAccountAsync(Account p) => await AccountDao.Instance.DeleteAsync(p);
        public async Task<Account> GetAccountByIdAsync(string id) => await AccountDao.Instance.GetByIdAsync(id);
        public async Task<List<Account>> GetAccountsAsync() => await AccountDao.Instance.ShowAllAsync();
        public async Task SaveAccountAsync(Account p) => await AccountDao.Instance.CreateAsync(p);
        public async Task UpdateAccountAsync(Account p) => await AccountDao.Instance.UpdateAsync(p);
    }
}
