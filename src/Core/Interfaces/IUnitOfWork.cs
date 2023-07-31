namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    void Commit();
}