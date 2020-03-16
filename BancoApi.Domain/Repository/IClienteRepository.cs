using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Repository
{
    public interface IClienteRepository
    {
        public IEnumerable<Cliente> BuscarTodosClientes();
        public Cliente BuscarClientePorIdEndereco(int id);
        public Cliente BuscarClientePorIdContaPoupanca(int id);
        public Cliente BuscarClientePorIdContaCorrente(int id);
        public Cliente BuscarClientePorId(int id);

        
        void AdicionarCliente(Cliente cliente);
        bool ExisteCpf(string documento);
        bool ExisteEmail(string documento);
    }
}
