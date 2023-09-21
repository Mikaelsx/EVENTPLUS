using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext ctx;

        public EventoRepository()
        {
            ctx = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            throw new NotImplementedException();
        }

        public Evento BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        // Falha
        public void Cadastrar(Evento evento)
        {
            try
            {
                ctx.Evento.Add(evento);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            Evento tipoBuscado = ctx.Evento.Find(id)!;

            if (tipoBuscado != null)
            {
                ctx.Evento.Remove(tipoBuscado);
            }

            ctx.SaveChanges();
        }

        // Falha
        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }
    }
}
