using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly INotificador _notificador;

        public UsuarioService(IUsuarioRepository usuarioRepository, INotificador notificador)
        {
            _usuarioRepository = usuarioRepository;
            _notificador = notificador;
        }

        public Usuario Login(Usuario usuario)
        {
            Usuario usuarioRetorno = _usuarioRepository.Login(usuario);

            if (usuarioRetorno == null)
                _notificador.Adicionar("Usuário ou senha Inválida");

            return usuarioRetorno;
        }


        public bool Adicionar(Usuario usuario)
        {
            _usuarioRepository.Adicionar(usuario);
            return true;
        }
    }
}
