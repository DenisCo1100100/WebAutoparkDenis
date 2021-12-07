using System.Collections.Generic;

namespace WebAutopark.DataBaseAccess.Repository.Base
{
    interface IRepository<T> 
        where T : class
    {
        public IEnumerable<T> GetAllItems();
        public T GetItem(int id);
        public void Create(T item);
        public void Update(T item);
        public void Delete(int id);
    }
}