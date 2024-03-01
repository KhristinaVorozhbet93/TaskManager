using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> FindAccountByEmail(string email, CancellationToken cancellationToken);
        Task<Account?> FindAccountById(Guid id, CancellationToken cancellationToken);
        Task<Account> GetAccountByEmail(string email, CancellationToken cancellationToken); 

    }
}
