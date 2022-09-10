using Microsoft.EntityFrameworkCore;
using MSA_Phase_3.Domain.Models;

namespace MSA_Phase_3.Service.Data
{
    public class ProjDbContext : DbContext
    {


        public ProjDbContext(DbContextOptions<ProjDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>()
                .HasKey(ub => new { ub.UserName, ub.BookId });
            modelBuilder.Entity<UserBook>()
                .HasOne(ub => ub.Book)
                .WithMany(ub => ub.UserBooks)
                .HasForeignKey(ub => ub.BookId);
            modelBuilder.Entity<UserBook>()
                .HasOne(ap => ap.User)
                .WithMany(ap => ap.UserBooks)
                .HasForeignKey(ap => ap.UserName)
                .OnDelete(DeleteBehavior.Restrict);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }

    }
}
