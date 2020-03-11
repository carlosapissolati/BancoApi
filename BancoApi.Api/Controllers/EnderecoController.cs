using AutoMapper;
using BancoApi.Api.Models;
using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BancoApi.Api.Controllers
{
    [Route("Endereco")]
    public class EnderecoController : Controller
    {

        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;
        private readonly IEnderecoService _enderecoService;
        private readonly INotificador _notificador;

        public EnderecoController(IMapper mapper, IEnderecoRepository enderecoRepository, IEnderecoService enderecoService, INotificador notificador)
        {
            _enderecoRepository = enderecoRepository;
            _mapper = mapper;
            _enderecoService = enderecoService;
            _notificador = notificador;
        }


        [HttpPost]
        public ActionResult<EnderecoViewModel> AdicionarEndereco([FromBody]EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(e => e.Errors);
                foreach (var erro in erros)
                {
                    var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                    _notificador.Adicionar(errorMsg);
                }

                return BadRequest(new { Error = _notificador.ObterNotificacoes().Select(n => n.Mensagem) });
            }

            var endereco = _mapper.Map<Endereco>(enderecoViewModel);
            _enderecoService.Adicionar(endereco);

            var enderecoViewModelResult = _mapper.Map<EnderecoViewModel>(endereco);
            return Ok(enderecoViewModelResult);
        }
    }
}
