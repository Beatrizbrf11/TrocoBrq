using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrocoBrq.Aplication.ViewModels
{
    public class RetornoViewModel
    {
        public bool Status { get; set; }
        public string Mensagem { get; set; }
        public List<MoedaViewModel> MoedasRetorno { get; set; }
    }
}
