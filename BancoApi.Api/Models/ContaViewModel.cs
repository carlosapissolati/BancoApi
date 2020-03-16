using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BancoApi.Api.Models
{
    public class ContaViewModel
    {
        public int Id { get; set; }
        public double Saldo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ClienteId { get; set; }

    }
}
