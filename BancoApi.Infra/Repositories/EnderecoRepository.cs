using BancoApi.Domain.Entities;
using BancoApi.Domain.Repository;
using BancoApi.Infra.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Z.Dapper.Plus;

namespace BancoApi.Infra.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly BancoContext _context;

        public EnderecoRepository(BancoContext context)
        {
            _context = context;
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            DapperPlusManager.Entity<Endereco>().Table("Endereco").Identity(x => x.Id, true);
            _context.Connection.BulkInsert(endereco);
        }
    }
}
