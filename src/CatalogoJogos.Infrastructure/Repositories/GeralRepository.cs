using System.Threading.Tasks;
using CatalogoJogos.Infrastructure.Context;
using CatalogoJogos.Infrastructure.Interfaces;

namespace CatalogoJogos.Infrastructure.Repositories
{
    public class GeralRepository : IGeralRepository
    {
        private readonly CatalogoJogosContext context;
        public GeralRepository(CatalogoJogosContext context)
        {
            this.context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            context.Update(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            context.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}