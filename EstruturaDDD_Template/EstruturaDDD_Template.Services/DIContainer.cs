using TrocoBrq.Data.Context;
using TrocoBrq.Data.Repository;
using TrocoBrq.Domain.Entities;
using TrocoBrq.Domain.Interface.Repository;
using TrocoBrq.Domain.Interface.Service;
using TrocoBrq.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Text;
using TrocoBrq.Cross.DTO;

namespace TrocoBrq.Services
{
    public static class DIContainer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<CoreContext>();
            #region Repository

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBaseRepository<Moeda, MoedaDTO>, BaseRepository<Moeda, MoedaDTO>>();

            #endregion

            #region Service

            services.AddScoped<IMoedaService, MoedaService>();

            #endregion
        }
    }
}
