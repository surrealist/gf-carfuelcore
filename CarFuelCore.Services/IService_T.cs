using System;
using System.Linq;

namespace CarFuelCore.Services
{
  public interface IService<T> where T : class {

    IQueryable<T> All();
    IQueryable<T> Query(Func<T, bool> criteria);

    T Find(params object[] keys);

    T Add(T item);
    T Remove(T item);

    int SaveChanges();
  }

}
