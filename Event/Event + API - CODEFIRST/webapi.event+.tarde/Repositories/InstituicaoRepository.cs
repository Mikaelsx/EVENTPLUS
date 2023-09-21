using webapi.event_.tarde.Contexts;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
            private readonly EventContext ctx;

            public InstituicaoRepository()
            {
                ctx = new EventContext();
            }

            // Falha
            public void Atualizar(Guid id, Instituicao instituicao)
            {
            Instituicao tipoBuscado = ctx.Instituicao.Find(id)!;

            if (tipoBuscado != null)
            {
                tipoBuscado.NomeFantasia = tipoBuscado.NomeFantasia;
            }

            ctx.Instituicao.Update(tipoBuscado!);

            ctx.SaveChanges();
        }
            
            // Funcionando
            public Instituicao BuscarPorId(Guid id)
            {
            return ctx.Instituicao.FirstOrDefault(e => e.IdInstituicao == id)!;
            }

            // Funcionando
            public void Cadastrar(Instituicao instituicao)
            {
                try
                {
                    ctx.Instituicao.Add(instituicao);
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
            Instituicao tipoBuscado = ctx.Instituicao.Find(id)!;

            if (tipoBuscado != null)
            {
                ctx.Instituicao.Remove(tipoBuscado);
            }

            ctx.SaveChanges();
            }
            
            // Funcionando
            public List<Instituicao> Listar()
            {
                return ctx.Instituicao.ToList();
            }
    }
}
