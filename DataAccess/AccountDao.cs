using BussinessObject;
using DataAccess.IDao;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AccountDao : Singleton<AccountDao>, IObjectDAO<Account>
    {
        private readonly IMongoCollection<Account> _Accounts;
        private readonly GetFilter<Account> _filterHelper;

        public AccountDao()
        {
            var context = new SocialDbContext();
            _Accounts = context.Accounts;
            _filterHelper = new GetFilter<Account>();  // Initialize filter helper
        }

        public async Task CreateAsync(Account user)
        {
            try
            {
                user.CreatedAt = DateTime.UtcNow;
                await _Accounts.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting account: " + ex.Message);
            }
        }

        public async Task DeleteAllAsync()
        {
            try
            {
                await _Accounts.DeleteManyAsync(FilterDefinition<Account>.Empty);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting accounts: " + ex.Message);
            }
        }

        public async Task DeleteAsync(Account account)
        {
            try
            {
                var filter = _filterHelper.GetFilterById(a => a.Id.ToString(), account.Id.ToString());
                await _Accounts.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting account: " + ex.Message);
            }
        }

        public async Task<Account> GetByIdAsync(string id)
        {
            try
            {
                var filter = _filterHelper.GetFilterById(a => a.Id.ToString(), id); // Use the filter helper
                var account = await _Accounts.Find(filter).FirstOrDefaultAsync();

                return account ?? throw new Exception("Account not found");
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving account: " + ex.Message);
            }
        }

        public async Task<List<Account>> ShowAllAsync()
        {
            try
            {
                return await _Accounts.Find(FilterDefinition<Account>.Empty).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving accounts: " + ex.Message);
            }
        }

        public async Task UpdateAsync(Account account)
        {
            try
            {
                var filter = _filterHelper.GetFilterById(a => a.Id.ToString(), account.Id.ToString());
                await _Accounts.ReplaceOneAsync(filter, account);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating account: " + ex.Message);
            }
        }
    }
}
