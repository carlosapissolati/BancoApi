using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Repository
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);

        public Usuario Login(Usuario usuario);
    }
}
