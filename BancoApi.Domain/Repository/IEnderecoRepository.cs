using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Repository
{
    public interface IEnderecoRepository
    {
        public void AdicionarEndereco(Endereco endereco);
    }
}
