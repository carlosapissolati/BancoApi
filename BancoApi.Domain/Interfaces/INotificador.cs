using BancoApi.Domain.Notificacoes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Interfaces
{
    public interface INotificador
    {
        void Adicionar(string mensagem);
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
    }
}
