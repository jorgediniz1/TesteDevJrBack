namespace TesteVagaJr.Core;

public interface IUnitOfWork
{
    Task<bool> Commit();
}