using System;
using System.Linq;

namespace CarFuelCore.Data
{
  public interface IRepository<T> where T : class {

    IQueryable<T> Query(Func<T, bool> criteria);

    T Add(T item);
    T Remove(T item);
    int SaveChanges();
    
  }

}
