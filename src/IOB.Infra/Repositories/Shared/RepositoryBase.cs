﻿using IOB.Domain.Entidades.Shared;
using IOB.Domain.Interfaces.Repositories.Shared;
using IOB.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace IOB.Infra.Repositories.Shared;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entidade
{
    protected readonly IobContext Context;

    public RepositoryBase(IobContext dataContext) =>
        Context = dataContext;

    public virtual async Task<IEnumerable<TEntity>> ObterPorFiltroAsync(
          System.Linq.Expressions.Expression<Func<TEntity, bool>>? filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
          string includeProperties = "")
    {
        IQueryable<TEntity> query = Context.Set<TEntity>();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual async Task<IEnumerable<TEntity>> ObterTodosAsync() =>
        await Context.Set<TEntity>()            
            .AsNoTracking()
            .ToListAsync();

    public virtual async Task<TEntity?> ObterPorIdAsync(int id) =>
        await Context.Set<TEntity>().FindAsync(id);

    public virtual async Task<object> AdicionarAsync(TEntity objeto)
    {
        Context.Add(objeto);
        await Context.SaveChangesAsync();
        return objeto.Id;
    }

    public virtual async Task AtualizarAsync(TEntity objeto)
    {
        Context.Entry(objeto).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public virtual async Task RemoverAsync(TEntity objeto)
    {
        Context.Set<TEntity>().Remove(objeto);
        await Context.SaveChangesAsync();
    }

    public virtual async Task RemoverPorIdAsync(int id)
    {
        var objeto = await ObterPorIdAsync(id);
        if (objeto == null)
            throw new Exception("O registro não existe na base de dados.");
        await RemoverAsync(objeto);
    }

    public void Dispose() =>
        Context.Dispose();
}
