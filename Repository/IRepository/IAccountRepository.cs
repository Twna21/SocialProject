using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepository
{
    public interface IAccountRepository
    {
        Task SaveAccountAsync(Account p);
        Task<Account> GetAccountByIdAsync(string id);
        Task DeleteAccountAsync(Account p);
        Task UpdateAccountAsync(Account p);
        Task<List<Account>> GetAccountsAsync();
    }
}
