using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CarFuelCore.Data {
  public class RepositoryBase<T> : IRepository<T> where T : class {

    private readonly DbContext _context;

    public RepositoryBase(DbContext context) => _context = context;
    
    public IQueryable<T> Query(Func<T, bool> criteria) 
      => _context.Set<T>().Where(criteria).AsQueryable();

    public T Add(T item) => _context.Set<T>().Add(item).Entity;
    public IQueryable<T> All() => _context.Set<T>().AsQueryable();
    public T Remove(T item) => _context.Set<T>().Remove(item).Entity;
    public int SaveChanges() => _context.SaveChanges();
  }
}
