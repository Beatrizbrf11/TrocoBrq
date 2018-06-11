using TrocoBrq.Cross.DTO;
using TrocoBrq.Data.Context;
using TrocoBrq.Data.Repository;
using TrocoBrq.Domain.Entities;
using TrocoBrq.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public CoreContext _context;

        private bool disposed = false;

        public UnitOfWork(CoreContext context)
        {
            _context = context;
        }
        
        private IBaseRepository<Moeda,MoedaDTO> moedaRepository;

        public IBaseRepository<Moeda, MoedaDTO> MoedaRepository
        {
            get
            {
                if (moedaRepository == null)
                    moedaRepository = new BaseRepository<Moeda, MoedaDTO>(_context);
                return moedaRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}