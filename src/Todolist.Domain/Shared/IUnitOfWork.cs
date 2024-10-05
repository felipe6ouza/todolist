namespace Todolist.Domain.Shared
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
