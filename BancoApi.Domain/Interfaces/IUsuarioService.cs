using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Interfaces
{
    public interface IUsuarioService
    {
        public Usuario Login(Usuario usuario);
        public bool Adicionar(Usuario usuario);
    }
}
