using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TrocoBrq.Domain.Entities
{
    public class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? DataCriadao { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime? UpdatedOn { get; set; }
        public bool Active { get; set; }
    }
}
