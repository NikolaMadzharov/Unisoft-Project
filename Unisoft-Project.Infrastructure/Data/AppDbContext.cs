using Microsoft.EntityFrameworkCore;

using Unisoft_Project.Infrastructure.Data.Entities;

namespace Unisoft_Project.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
