using System;
using System.Collections.Generic;
using System.Text;

namespace BancoApi.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public int Status { get; set; }
    }
}
