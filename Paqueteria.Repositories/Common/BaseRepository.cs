
using Paqueteria.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paqueteria.Repositories.Common
{
    public class BaseRepository<T> where T : class
    {
        protected DBContext _context;

        #region Get All
        public virtual IEnumerable<T> GetAll()
        {
            return  _context.Set<T>().ToList();
        }
        #endregion

        #region GetOne
        public T Get(long id)
        {
            return _context.Set<T>().Find(id);
        }
        #endregion

        #region Add
        public virtual void Add(T t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public virtual void Add(IEnumerable<T> t)
        {
            _context.Add(t);
            _context.SaveChanges();
        }

        public virtual async Task AddAsync(T t)
        {
            await _context.AddAsync(t);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Remove
        public virtual void Delete(long id)
        {
            T t = Get(id);
            _context.Remove(t);
            _context.SaveChanges();
        }
        #endregion

        #region Update
        public virtual void Update(T t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }

        public virtual void Update(IEnumerable<T> t)
        {
            _context.Update(t);
            _context.SaveChanges();
        }
        #endregion

        #region Exist
        public virtual bool Exist(long id)
        {
            return Get(id) != null;
        }
        #endregion
    }
}
