using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BancoApi.Api.Models
{
    public class ContaOperacaoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }
    }
}
