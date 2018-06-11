using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Cross.DTO
{
    public class MoedaDTO : EntityDTO, IEntityDTO
    {
        public decimal Valor { get; set; }
        public decimal Quantidade { get; set; }
        public int NotasRetornadas { get; set; }
    }
}
