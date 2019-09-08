using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace mbensaeed.Repositories
{
    interface IRepositoryPattern<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetByID(Int32 ID);
        T GetByPredicate(Expression<Func<T, bool>> predicate);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        T GetByString(string StrVal);
        T GetByInt(int IntVal);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object ID);
        void DeleteMoreItem(Expression<Func<T, bool>> predicate);
        void Save();
    }
}