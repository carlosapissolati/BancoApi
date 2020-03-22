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
    [Route("Cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;
        private readonly INotificador _notificador;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper, IClienteService clienteService, INotificador notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _clienteService = clienteService;
            _notificador = notificador;
        }


        [HttpGet]
        [Route("")]
        public IEnumerable<ClienteViewModel> BuscarTodosClientes()
        {
            IEnumerable<Cliente> clientes = _clienteRepository.BuscarTodosClientes();
            var clientesViewModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            return clientesViewModel;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<ClienteViewModel> BuscarClientePorId(int id)
        {
            Cliente clientes = _clienteRepository.BuscarClientePorId(id);
            if (clientes == null)
                return NotFound();

            var clienteViewModel = _mapper.Map<ClienteViewModel>(clientes);
            return Ok(clienteViewModel);
        }

        [HttpGet]
        [Route("{id:int}/endereco")]
        public ActionResult<ClienteViewModel> BuscarClientePorIdEndereco(int id)
        {
            Cliente clientes = _clienteRepository.BuscarClientePorIdEndereco(id);
            if (clientes == null)
                return NotFound();

            var clienteViewModel = _mapper.Map<ClienteViewModel>(clientes);
            return Ok(clienteViewModel);
        }

        [HttpGet]
        [Route("{id:int}/contacorrente")]
        public ActionResult<ClienteViewModel> BuscarClientePorIdContaCorrente(int id)
        {
            Cliente clientes = _clienteRepository.BuscarClientePorIdContaCorrente(id);
            if (clientes == null)
                return NotFound();

            var clienteViewModel = _mapper.Map<ClienteViewModel>(clientes);
            return Ok(clienteViewModel);
        }

        [HttpGet]
        [Route("{id:int}/contapoupanca")]
        public ActionResult<ClienteViewModel> BuscarClientePorIdContaPoupanca(int id)
        {
            Cliente clientes = _clienteRepository.BuscarClientePorIdContaPoupanca(id);
            if (clientes == null)
                return NotFound();

            var clienteViewModel = _mapper.Map<ClienteViewModel>(clientes);
            return Ok(clienteViewModel);
        }

        [HttpPost]
        public ActionResult<ClienteViewModel> Adicionar([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelError.GetErrorModelState(ModelState));

    
            var cliente = _mapper.Map<Cliente>(clienteViewModel);

            if (!_clienteService.Adicionar(cliente))
                return BadRequest(ModelError.GetErrorValidacao(_notificador));
  

            var clienteViewModelResult = _mapper.Map<ClienteViewModel>(cliente);

            return Ok(clienteViewModelResult);
        }
    }
}
