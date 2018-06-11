using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Domain.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string CriadoPor { get; set; }
        DateTime? DataCriadao { get; set; }
        //string UpdatedBy { get; set; }
        //DateTime? UpdatedOn { get; set; }
        bool Active { get; set; }
    }
}
