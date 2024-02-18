using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.DataEntityFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> Notes => Set<Note>();
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}
    }
}
