using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext ctx;

        public TipoEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            TipoEvento tipoBuscado = ctx.TipoEvento.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipoBuscado.Titulo;
            }

            ctx.TipoEvento.Update(tipoBuscado!);

            ctx.SaveChanges();
        }

        // Funcionando
        public TipoEvento BuscarPorId(Guid id)
        {
            return ctx.TipoEvento.FirstOrDefault(e => e.IdTipoEvento == id)!;
        }


        // Funcionando
        public void Cadastrar(TipoEvento tipoEvento)
        {
            try
            {
                ctx.TipoEvento.Add(tipoEvento);
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
            TipoEvento tipoBuscado = ctx.TipoEvento.Find(id)!;

            if (tipoBuscado != null)
            {
                ctx.TipoEvento.Remove(tipoBuscado);
            }

            ctx.SaveChanges();
        }

        // Funcionando
        public List<TipoEvento> Listar()
        {
            return ctx.TipoEvento.ToList();
        }
    }
}
