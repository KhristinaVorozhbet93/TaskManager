using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.DataEntityFramework.Repositories
{
    public class AccountRepository : EFRepository<Account>, IAccountRepository 
    {
        public AccountRepository(AppDbContext dbContext) 
            : base(dbContext) { }

        public async Task<Account?> FindAccountByEmail(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            return await Entities.SingleOrDefaultAsync(it => it.Email == email, cancellationToken); 
        }
    }
}
