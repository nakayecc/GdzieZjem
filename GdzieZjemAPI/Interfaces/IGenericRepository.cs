using System.Collections.Generic;

namespace GdzieZjemAPI.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Delete(object id);
        void Update(T obj);
        void Save();
    }
}