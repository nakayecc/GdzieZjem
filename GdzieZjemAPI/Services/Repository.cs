using System.Collections.Generic;
using System.Linq;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GdzieZjemAPI.Services
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private ApiContext _context;
        private DbSet<T> table;

        public Repository(ApiContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public DbSet<T> GetContext()
        {
            return table;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Delete(object id)
        {
            T exists = table.Find(id);
            table.Remove(exists);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}