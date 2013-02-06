// -----------------------------------------------------------------------
// <copyright file="IBaseRepository.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace FrozenBytes.Tdd.Legacy.Demo.Infrastructure.Repositories
{
    using System.Collections.Generic;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public interface IBaseRepository <T> where T : class
    {
        IList<T> GetAll();
        //IQueryable<T> GetAll();
        //IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        //IQueryable<T> Include(string includes);
        T Get(int id);
        T Add(T entity);
        //void Delete(int id);
        //void Edit(T entity);
        void Save();
    }
}
