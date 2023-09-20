using Microsoft.Data.SqlClient;
using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new EventContext();
        }

        // Falha
        public void Atualizar(Guid id, TipoUsuario tipoUsuario)
        {
                TipoUsuario tipoBuscado = ctx.TipoUsuario.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.Titulo = tipoBuscado.Titulo;
                }

                ctx.TipoUsuario.Update(tipoBuscado!);

                ctx.SaveChanges();
            }

        // Funcionando
        public TipoUsuario BuscarPorId(Guid id)
        {
            return ctx.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id)!;
        }

        // Funcionando
        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(tipoUsuario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Funcionando
        public void Deletar(Guid id)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuario.Find(id)!;

            if (tipoBuscado != null)
            {
                ctx.TipoUsuario.Remove(tipoBuscado);
            }

            ctx.SaveChanges();
        }

        // Funcionando
        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList(); 
        }
    }
}
