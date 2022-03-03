
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paqueteria.Repositories.Common
{
    public interface ICRUDRepository<T> where T : class
    {
        #region Create
        void Add(T t);
        void Add(IEnumerable<T> t);
        Task AddAsync(T t);
        #endregion

        #region Read
        IEnumerable<T> GetAll();
        bool Exist(long id);
        T Get(long id);
        #endregion

        #region Update
        void Update(T t);
        void Update(IEnumerable<T> t);
        #endregion

        #region Delete
        void Delete(long id);
        #endregion
    }
}
