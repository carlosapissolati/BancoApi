using BancoApi.Domain.Entities;
using BancoApi.Domain.Repository;
using BancoApi.Infra.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Z.Dapper.Plus;

namespace BancoApi.Infra.Repositories
{
    public class ContaPoupancaRepository : IContaPoupancaRepository
    {

        private readonly BancoContext _context;

        public ContaPoupancaRepository(BancoContext context)
        {
            _context = context;
        }

        public void AlterarConta(ContaPoupanca contaPoupanca)
        {
            DapperPlusManager.Entity<ContaCorrente>().Table("ContaPoupanca");
             _context.Connection.BulkUpdate(contaPoupanca);
        }

        public ContaPoupanca BuscarContaPorId(int id)
        {
            return _context.Connection.Query<ContaPoupanca>("SELECT * FROM ContaPoupanca WHERE id=@id", new { id = id }).FirstOrDefault();
        }

        public void CriarConta(ContaPoupanca contaPoupanca)
        {
            DapperPlusManager.Entity<ContaCorrente>().Table("ContaPoupanca").Identity(x => x.Id, true);
            _context.Connection.BulkInsert(contaPoupanca);
        }

        public bool ExisteConta(int id)
        {
            return _context
                .Connection
                .Query<bool>("SELECT CASE WHEN EXISTS (SELECT [Id] FROM contapoupanca WHERE [id] = @id) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END as retorno"
                , new { id = id }).
                FirstOrDefault();
        }
    }
}
