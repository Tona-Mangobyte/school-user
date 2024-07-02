namespace SchoolUser.Application.Interfaces.UnitOfWorks
{
    public interface IUserUnitOfWork: IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}