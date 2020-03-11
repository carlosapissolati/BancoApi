using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;

namespace BancoApi.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly INotificador _notificador;

        public ClienteService(IClienteRepository clienteRepository, INotificador notificador)
        {
            _clienteRepository = clienteRepository;
            _notificador = notificador;
        }

        public bool Adicionar(Cliente cliente)
        {
            if (!cliente.ValidarCpf(cliente.Cpf))
            {
                _notificador.Adicionar("CPF Inválido");
                return false;
            }

            if (_clienteRepository.ExisteCpf(cliente.Cpf))
            {
                _notificador.Adicionar("CPF já cadastro");
                return false;
            }
               

            if (_clienteRepository.ExisteEmail(cliente.Email))
            {
                _notificador.Adicionar("Email já ceadastrado");
                return false;
            }

            _clienteRepository.AdicionarCliente(cliente);

            return true;
        }
    }
}
