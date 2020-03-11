using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Interfaces
{
   public interface IClienteService
    {
        public bool Adicionar(Cliente cliente);
    }
}
