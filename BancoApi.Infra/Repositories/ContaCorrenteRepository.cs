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
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {

        private readonly BancoContext _context;

        public ContaCorrenteRepository(BancoContext context)
        {
            _context = context;
        }

        public void CriarContaCorrente(ContaCorrente contaCorrente)
        {
            DapperPlusManager.Entity<ContaCorrente>().Table("ContaCorrente").Identity(x => x.Id, true);
            _context.Connection.BulkInsert(contaCorrente);
        }

        public void AlterarContaCorrente(ContaCorrente contaCorrente)
        {
            DapperPlusManager.Entity<ContaCorrente>().Table("contacorrente");
            _context.Connection.BulkUpdate(contaCorrente);
        }

        public ContaCorrente BuscarContaCorrentePorId(int id)
        {
            return _context.Connection.Query<ContaCorrente>("SELECT * FROM ContaCorrente WHERE id=@id", new { id = id }).FirstOrDefault();
        }

        public bool ExisteContaCorrente(int id)
        {
            return _context
             .Connection
             .Query<bool>("SELECT CASE WHEN EXISTS (SELECT [Id] FROM ContaCorrente WHERE [id] = @id) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END as retorno"
             , new { id = id }).
             FirstOrDefault();
        }
    }
}
