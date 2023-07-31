namespace Core.Interfaces;

public interface IGenericRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
    where TId : struct
{
    TEntity? GetById(TId id);
    IReadOnlyCollection<TEntity> GetAll();
    void Add(TEntity entity);
    void Delete(TEntity entity);
}