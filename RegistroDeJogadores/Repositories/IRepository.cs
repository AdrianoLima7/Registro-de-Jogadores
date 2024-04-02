using System.Linq.Expressions;

namespace RegistroDeJogadores.Repositories;

public interface IRepository<T> 
{
    Task<IEnumerable<T>> GetAllAsync();

    Task<T?> Get(Expression<Func<T, bool>> predicate);

    T? Create(T entity);

    T? Update(T entity);

    T? Delete(T entity);
}
