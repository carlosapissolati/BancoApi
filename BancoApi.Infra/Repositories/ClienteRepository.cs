using BancoApi.Domain.Entities;
using BancoApi.Domain.Repository;
using BancoApi.Infra.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.Dapper.Plus;

namespace BancoApi.Infra.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly BancoContext _context;

        public ClienteRepository(BancoContext context)
        {
            _context = context;
        }

        public void AdicionarCliente(Cliente cliente)
        {
            DapperPlusManager.Entity<Cliente>().Table("Cliente").Identity(x => x.Id, true);
            _context.Connection.BulkInsert(cliente);
        }

        public Cliente BuscarClientePorIdEndereco(int id)
        {
            var query = @"
                SELECT * FROM Cliente WHERE ID = @Id
                SELECT * FROM Endereco WHERE ClienteId = @Id
                ";
            var result = _context.Connection.QueryMultiple(query, new { id });

            Cliente cliente = result.Read<Cliente>().Single();
            cliente.Endereco = result.Read<Endereco>().ToList();

            return cliente;
        }

        public Cliente BuscarClientePorId(int id)
        {
            return _context.Connection.Query<Cliente>("SELECT * FROM Cliente WHERE id=@id", new { id = id }).FirstOrDefault();
        }

        public IEnumerable<Cliente> BuscarTodosClientes()
        {
            return _context.Connection.Query<Cliente>("SELECT * FROM Cliente", new { });
        }

        public bool ExisteCpf(string cpf)
        {
            return
             _context
             .Connection
             .Query<bool>("SELECT CASE WHEN EXISTS (SELECT [Id] FROM Cliente WHERE [cpf] = @cpf) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END as retorno"
             , new { cpf = cpf }).
             FirstOrDefault();
        }

        public bool ExisteEmail(string email)
        {
            return
            _context
            .Connection
            .Query<bool>("SELECT CASE WHEN EXISTS (SELECT [Id] FROM Cliente WHERE [Email] = @email) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END as retorno"
            , new { email = email }).
            FirstOrDefault();
        }
    }
}
