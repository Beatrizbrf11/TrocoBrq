using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Domain.Entities
{
    public class Moeda : Entity , IEntity
    {
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public int NotasRetornadas { get; set; }

    }
}
