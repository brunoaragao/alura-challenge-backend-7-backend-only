namespace Core.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : class, IEntity
{
    public TEntity[] Get();

    public TEntity? Get(long id);

    public void Add(TEntity entity);

    public void AddOrUpdate(TEntity entity, out bool added);

    public void Remove(long id);
}