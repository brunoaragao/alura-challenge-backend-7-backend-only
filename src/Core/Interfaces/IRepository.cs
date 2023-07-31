namespace Core.Interfaces;

public interface IRepository<TEntity, TId> : IDisposable
    where TEntity : class, IEntity<TId>
    where TId : struct
{
}