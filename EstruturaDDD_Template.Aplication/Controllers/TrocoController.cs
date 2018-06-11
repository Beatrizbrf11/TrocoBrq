using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrocoBrq.Aplication.ViewModels;
using TrocoBrq.Cross.DTO;
using TrocoBrq.Domain.Interface.Service;

namespace TrocoBrq.Aplication.Controllers
{
    public class TrocoController : Controller
    {
        public readonly IMoedaService _service;

        public TrocoController(IMoedaService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //http://localhost:64931/Troco/Index?valorDivida=150&valorEntregue=200
        public async Task<IActionResult> VerificarTroco(decimal valorDivida, decimal valorEntregue)
        {
            var retorno = await _service.ObterTroco((decimal)valorDivida, (decimal)valorEntregue);
            var mappedEntity = Mapper.Map<RetornoViewModel>(retorno);
            return View(mappedEntity);
        }
    }
}