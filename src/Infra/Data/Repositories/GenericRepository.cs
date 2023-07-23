namespace Infra.Data.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class, IEntity
{
    protected readonly DbSet<TEntity> _set;

    public GenericRepository(AppDbContext context)
    {
        _set = context.Set<TEntity>();
    }

    public TEntity[] Get()
    {
        return _set.ToArray();
    }

    public TEntity? Get(long id)
    {
        return _set.Find(id);
    }

    public void Add(TEntity entity)
    {
        _set.Add(entity);
    }

    public void Remove(long id)
    {
        _set.Where(e => e.Id == id)
            .ExecuteDelete();
    }

    public void AddOrUpdate(TEntity entity, out bool added)
    {
        _set.Update(entity);

        added = _set.Entry(entity).State is Added;
    }
}