using TrocoBrq.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrocoBrq.Domain.Interface.Service
{
    public interface IMoedaService
    {
        Task<RetornoDTO> ObterTroco(decimal valorDivida, decimal valorEntregue);
    }
}
