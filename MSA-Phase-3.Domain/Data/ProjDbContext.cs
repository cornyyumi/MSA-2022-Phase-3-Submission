using Microsoft.EntityFrameworkCore;
using MSA_Phase_3.Domain.Models;

namespace MSA_Phase_3.Domain.Data
{
    public class ProjDbContext : DbContext
    {
        public ProjDbContext(DbContextOptions<ProjDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

    }
}
