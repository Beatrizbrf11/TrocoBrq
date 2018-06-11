using TrocoBrq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity, TEntityDTO> : IDisposable
        where TEntity : class
        where TEntityDTO : IEntityDTO
    {
        void Add(TEntityDTO entity);
        TEntityDTO GetById(Guid id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO entity);
        void Remove(int id);
    }
}
