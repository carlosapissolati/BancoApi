using AutoMapper;
using BancoApi.Api.Extensions;
using BancoApi.Api.Models;
using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoApi.Api.Controllers
{
    [Authorize]
    [Route("ContaCorrente")]
    public class CorrenteController : Controller
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMapper _mapper;
        private readonly IContaService _contaCorrenteService;
        private readonly INotificador _notificador;

        public CorrenteController(IContaCorrenteRepository contaCorrenteRepository, IMapper mapper, IContaService contaCorrenteService, INotificador notificador)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
            _mapper = mapper;
            _contaCorrenteService = contaCorrenteService;
            _notificador = notificador;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ContaViewModel> BuscarContaCorrentePorId(int id)
        {

             ContaCorrente  contaCorrente = _contaCorrenteRepository.BuscarContaCorrentePorId(id);
            if (contaCorrente == null)
                return NotFound();

            var contaCorrenteViewModel = _mapper.Map<ContaViewModel>(contaCorrente);
            return Ok(contaCorrenteViewModel);
        }

        [HttpPost]
        [Route("Depositar")]
        public ActionResult<ContaViewModel> Depositar([FromBody] ContaOperacaoViewModel contaOperacaoView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelError.GetErrorModelState(ModelState));

            ContaCorrente contaCorrente = (ContaCorrente) _contaCorrenteService.Depositar(contaOperacaoView.Id, contaOperacaoView.Valor);
            if (contaCorrente == null)
                return BadRequest(ModelError.GetErrorValidacao(_notificador));

            var contaCorrenteViewModel = _mapper.Map<ContaViewModel>(contaCorrente);
            return Ok(contaCorrenteViewModel);
        }

        [HttpPost]
        [Route("Sacar")]
        public ActionResult<ContaViewModel> Sacar([FromBody] ContaOperacaoViewModel contaOperacaoView)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelError.GetErrorModelState(ModelState));

            ContaCorrente contaCorrente = (ContaCorrente) _contaCorrenteService.Sacar(contaOperacaoView.Id, contaOperacaoView.Valor);
            if (contaCorrente == null)
                return BadRequest(ModelError.GetErrorValidacao(_notificador));

            var contaCorrenteViewModel = _mapper.Map<ContaViewModel>(contaCorrente);
            return Ok(contaCorrenteViewModel);
        }
    }
}
