using BancoApi.Domain.Entities;
using BancoApi.Domain.Interfaces;
using BancoApi.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Services
{

    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly INotificador _notificador;

        public EnderecoService(IEnderecoRepository enderecoRepository, INotificador notificador)
        {
            _enderecoRepository = enderecoRepository;
            _notificador = notificador;
        }


        public bool Adicionar(Endereco endereco)
        {

            _enderecoRepository.AdicionarEndereco(endereco);

            return true;
        }
    }
}
