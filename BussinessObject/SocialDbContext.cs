using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class SocialDbContext :DbContext
    {
        private readonly IMongoDatabase _database;
        public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("Account");
        // tuong tu cho cac Entry khac Post --> _database.GetCollection<Post>("Post");


        public SocialDbContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("DBCONTEXT");
            var mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase("PRN231_SocialProject");
        }
    }
}
