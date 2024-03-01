using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.DataEntityFramework.Repositories
{
    public class AccountRepository : EFRepository<Account>, IAccountRepository 
    {
        public AccountRepository(AppDbContext appDbContext) 
            : base(appDbContext) { }

        public async Task<Account?> FindAccountByEmail(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            return await Entities.SingleOrDefaultAsync(it => it.Email == email, cancellationToken); 
        }

        public async Task<Account?> FindAccountById(Guid id, CancellationToken cancellationToken)
        {
            return await Entities.SingleOrDefaultAsync(it => it.Id == id, cancellationToken);
        }

        public async Task<Account> GetAccountByEmail(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            return await Entities.SingleAsync(it => it.Email == email, cancellationToken);
        }
    }
}
