using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace mbensaeed.Repositories
{
    public class RepositoryPattern<T> : IRepositoryPattern<T> where T : class
    {
        private DbContext _context;
        private DbSet<T> _entity = null;
        public RepositoryPattern(DbContext context)
        {
            this._context = context;
            _entity = this._context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetByID(int ID)
        {
            return _entity.Single(x => x.Equals(ID));
            //return _entity.Find(ID);
        }
        //public T GetByID(string ID)
        //    {
        //        //return _entity.Single(x => x.Equals(ID));
        //        return _entity.Find(ID);
        //    }
        public T GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _entity.Single(predicate);
        }
            catch (Exception)
            {
                return _entity.FirstOrDefault(predicate);
                throw;
            }
}
        public void DeleteMoreItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                //var ListItems = _entity.Where(predicate);
                //if (ListItems == null)
                //    throw new ArgumentNullException("null");
                //foreach (var item in ListItems)
                //{
                //    _entity.Remove(item);
                //}

                _entity.Where(predicate)?.ToList().ForEach(x => _entity.Remove(x));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _entity.Where(predicate);
        }
        public T GetByString(string StrVal)
        {
            throw new NotImplementedException();
        }
        public T GetByInt(int IntVal)
        {
            return _entity.Find(IntVal);
        }
        public void Insert(T obj)
        {
            _entity.Add(obj);
        }
        public void Attach(T obj)
        {
            _entity.Attach(obj);
        }
        public void Update(T obj)
        {
            _entity.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object ID)
        {
            var item = _entity.Find(ID);
            _entity.Remove(item);
        }

        public void Save()
        {
            string strerr;
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        strerr = ("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }



        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        //public T GetByID(object ID)
        //{
        //    throw new NotImplementedException();
        //}
    }
}