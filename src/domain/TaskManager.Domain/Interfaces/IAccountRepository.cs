using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> FindAccountByEmail(string email, CancellationToken cancellationToken);
    }
}
