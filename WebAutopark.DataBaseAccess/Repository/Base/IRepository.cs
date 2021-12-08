using System.Collections.Generic;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    public interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> GetAllItems();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}