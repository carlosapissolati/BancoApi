using BancoApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoApi.Api.Extensions
{
    public static class ModelError
    {

        public static Object GetErrorModelState(ModelStateDictionary modelState)
        {
            ArrayList notificacao = new ArrayList();
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                notificacao.Add(errorMsg);
            }

            return new { Error = notificacao.ToArray() };
        }

        public static object GetErrorValidacao(INotificador notificador)
        {
            return new { Error = notificador.ObterNotificacoes().Select(x => x.Mensagem) };
        }

    }
}
