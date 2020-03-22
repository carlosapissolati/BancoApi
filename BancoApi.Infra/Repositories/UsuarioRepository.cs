using BancoApi.Domain.Entities;
using BancoApi.Domain.Repository;
using BancoApi.Infra.Context;
using Dapper;
using System.Linq;
using Z.Dapper.Plus;

namespace BancoApi.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly BancoContext _context;

        public UsuarioRepository(BancoContext context)
        {
            _context = context;
        }

        public void Adicionar(Usuario usuario)
        {
            DapperPlusManager.Entity<Usuario>().Table("Usuario").Identity(x => x.Id, true);
            _context.Connection.BulkInsert(usuario);
        }

        public Usuario Login(Usuario usuario)
        {
            Usuario usuarioRetorno = _context.Connection.Query<Usuario>("SELECT * FROM [Usuario] WHERE [Username] = @Username and [Password] = @Password"
            , new { Username = usuario.Username, Password = usuario.Password }).
            FirstOrDefault();

            return usuarioRetorno;
        }
    }
}
