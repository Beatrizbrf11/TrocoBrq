using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Domain.Interface.Service
{
    public interface IBaseService<TEntityDTO> where TEntityDTO : TrocoBrq.IEntityDTO
    {
        void Add(TEntityDTO entity);
        TEntityDTO GetById(Guid id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO entity);
        void Remove(int id);
        void Dispose();
    }
}
