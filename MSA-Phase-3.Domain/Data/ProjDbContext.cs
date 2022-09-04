using Microsoft.EntityFrameworkCore;
using MSA_Phase_3.Domain.Models;

namespace MSA_Phase_3.Domain.Data
{
    public class ProjDbContext : DbContext
    {

        
        public ProjDbContext(DbContextOptions<ProjDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


    }
}
