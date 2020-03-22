using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BancoApi.Api.Extensions;
using BancoApi.Api.Models;
using BancoApi.Api.Services;
using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;
using BancoApi.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BancoApi.Api.Controllers
{
    [Authorize]
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly INotificador _notificador;
        private readonly TokenService _tokenService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper, IUsuarioService usuarioService, INotificador notificador, TokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
            _usuarioService = usuarioService;
            _notificador = notificador;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelError.GetErrorModelState(ModelState));

            Usuario usuario = _mapper.Map<Usuario>(usuarioViewModel);

            Usuario usuarioRetorno = _usuarioService.Login(usuario);
            if(usuarioRetorno == null )
                return BadRequest(ModelError.GetErrorValidacao(_notificador));

            usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuarioRetorno);

            return Ok(
                new
                {
                    Usuario = usuarioViewModel.Username,
                    Token = _tokenService.GenerateToken(usuarioViewModel)
                });
        }
    }
}