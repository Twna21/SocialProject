using BussinessObject;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IDao
{
    public class GetFilter<T>
    {
        public FilterDefinition<T> GetFilterById(Expression<Func<T, string>> idSelector, string id)
        {
            return Builders<T>.Filter.Eq(idSelector, id);
        }
    }
}
