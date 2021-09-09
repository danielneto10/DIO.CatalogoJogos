using System.Threading.Tasks;

namespace CatalogoJogos.Infrastructure.Interfaces
{
    public interface IGeralRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Remove<T>(T entity) where T : class;
         Task SaveChangesAsync();
    }
}