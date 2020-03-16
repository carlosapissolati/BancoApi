using AutoMapper;
using BancoApi.Api.Extensions;
using BancoApi.Api.Models;
using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoApi.Api.Controllers
{
    [Route("ContaPoupanca")]
    public class PoupancaController : Controller
    {
        private readonly IContaPoupancaRepository _contaPoupancaRepository;
        private readonly IMapper _mapper;
        private readonly IContaService _contaService;
        private readonly INotificador _notificador;

        public PoupancaController(IContaPoupancaRepository contaPoupancaRepository, IMapper mapper, IContaService contaService, INotificador notificador)
        {
            _contaPoupancaRepository = contaPoupancaRepository;
            _mapper = mapper;
            _contaService = contaService;
            _notificador = notificador;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ContaViewModel> BuscarContaPoupancaPorId(int id)
        {

            ContaPoupanca contaPoupanca = _contaPoupancaRepository.BuscarContaPorId(id);
            if (contaPoupanca == null)
                return NotFound();

            var contaCorrenteViewModel = _mapper.Map<ContaViewModel>(contaPoupanca);
            return Ok(contaCorrenteViewModel);
        }

        [HttpPost]
        [Route("Depositar")]
        public ActionResult<ContaViewModel> Depositar([FromBody] ContaOperacaoViewModel contaOperacaoView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelError.GetErrorModelState(ModelState));

            ContaPoupanca contaPoupanca = (ContaPoupanca)_contaService.Depositar(contaOperacaoView.Id, contaOperacaoView.Valor);
            if (contaPoupanca == null)
                return BadRequest(ModelError.GetErrorValidacao(_notificador));

            var contaCorrenteViewModel = _mapper.Map<ContaViewModel>(contaPoupanca);
            return Ok(contaCorrenteViewModel);
        }

        [HttpPost]
        [Route("Sacar")]
        public ActionResult<ContaViewModel> Sacar([FromBody] ContaOperacaoViewModel contaOperacaoView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelError.GetErrorModelState(ModelState));

            ContaPoupanca contaPoupanca = (ContaPoupanca)_contaService.Sacar(contaOperacaoView.Id, contaOperacaoView.Valor);
            if (contaPoupanca == null)
                return BadRequest(ModelError.GetErrorValidacao(_notificador));

            var contaCorrenteViewModel = _mapper.Map<ContaViewModel>(contaPoupanca);
            return Ok(contaCorrenteViewModel);
        }
    }
}
