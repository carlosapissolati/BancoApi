using AutoMapper;
using BancoApi.Api.Models;
using BancoApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoApi.Api.AutoMapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<ContaCorrente, ContaViewModel > ().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }

    }
}
