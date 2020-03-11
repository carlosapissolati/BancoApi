using BancoApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoApi.Domain.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }


        public void Adicionar(string mensagem)
        {
            Notificacao notificacao = new Notificacao(mensagem);
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }


    }
}
