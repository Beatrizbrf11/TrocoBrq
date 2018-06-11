using TrocoBrq.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace TrocoBrq.Data.Context
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options) : base(options)
        {
            Database.AutoTransactionsEnabled = true;
        }
        
        public virtual DbSet<Moeda> Moeda { get; set; }
    }
}
