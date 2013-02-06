namespace FrozenBytes.Tdd.Legacy.Demo.Infrastructure.Repositories
{
    using System;
    using System.Collections.Generic;

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T Get(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T Add(T entity)
        {
            return entity;
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }
    }
}