using MSA_Phase_3.Domain.Models;

namespace MSA_Phase_3.Domain.Data
{
    public class ProjRepo : IProjRepo
    {
        private readonly ProjDbContext dbContext;
        public ProjRepo(ProjDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public User addUser(string username)
        {
            User user = new User
            {
                UserName = username
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }
    }
}
