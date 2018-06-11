using TrocoBrq.Cross.DTO;
using TrocoBrq.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Domain.Interface.Repository
{

    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Moeda,MoedaDTO> MoedaRepository { get; }
        void Commit();
    }
}
