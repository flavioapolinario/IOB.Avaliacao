using IOB.Domain.Entidades.Shared;

namespace IOB.Domain.Interfaces.Services.Shared;

public interface IServiceBase<TEntity> : IDisposable where TEntity : Entidade
{
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity?> ObterPorIdAsync(int id);
    Task<object> AdicionarAsync(TEntity objeto);
    Task AtualizarAsync(TEntity objeto);
    Task RemoverAsync(TEntity objeto);
    Task RemoverPorIdAsync(int id);
}
