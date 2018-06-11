using System;
using System.Collections.Generic;
using System.Text;

namespace TrocoBrq.Cross.DTO
{
    public class RetornoDTO
    {
        public bool Status { get; set; }
        public string Mensagem { get; set; }
        public List<MoedaDTO> MoedasRetorno { get; set; }
    }
}
