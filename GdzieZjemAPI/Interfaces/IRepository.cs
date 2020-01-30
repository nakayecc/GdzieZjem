using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GdzieZjemAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> GetContext();
        T GetById(object id);
        void Insert(T obj);
        void Delete(object id);
        void Update(T obj);
        void Save();
    }
}