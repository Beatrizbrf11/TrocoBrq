using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Cross.DTO
{
    public class EntityDTO
    {
        public Guid Id { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? DataCriacao { get; set; }
        public bool Active { get; set; }
    }
}
