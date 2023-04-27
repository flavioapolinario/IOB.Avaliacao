using IOB.Domain.Entidades.Shared;
using IOB.Domain.Interfaces.Repositories.Shared;
using IOB.Domain.Interfaces.Services.Shared;
using System.Linq.Expressions;

namespace IOB.Domain.Services.Shared;
public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : Entidade
{
    private readonly IRepositoryBase<TEntity> _repositoryBase;

    public ServiceBase(IRepositoryBase<TEntity> repositoryBase) =>
        _repositoryBase = repositoryBase;

    public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync() =>
        await _repositoryBase.ObterTodosAsync();

    public virtual async Task<TEntity?> ObterPorIdAsync(int id) =>
        await _repositoryBase.ObterPorIdAsync(id);

    public virtual async Task<object> AdicionarAsync(TEntity objeto) =>
        await _repositoryBase.AdicionarAsync(objeto);

    public virtual async Task AtualizarAsync(TEntity objeto) =>
        await _repositoryBase.AtualizarAsync(objeto);

    public virtual async Task RemoverAsync(TEntity objeto) =>
        await _repositoryBase.RemoverAsync(objeto);

    public virtual async Task RemoverPorIdAsync(int id) =>
        await _repositoryBase.RemoverPorIdAsync(id);

    public void Dispose() =>
        _repositoryBase.Dispose();

    public virtual async Task<IEnumerable<TEntity>> ObterPorFiltroAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "") =>
        await _repositoryBase.ObterPorFiltroAsync(filter, orderBy, includeProperties);
}