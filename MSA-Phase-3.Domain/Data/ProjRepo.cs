using MSA_Phase_3.Domain.Models;

namespace MSA_Phase_3.Domain.Data
{
    public class ProjRepo : IProjRepo
    {
        private readonly ProjDbContext _dbContext;
        public ProjRepo(ProjDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public User addUser(string username)
        {

            User user = _dbContext.Users.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                user = new User { UserName = username };
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> getUsers()
        {
            List<User> users = _dbContext.Users.ToList();
            return users;

        }
        public Book addBook(Book bookinfo)
        {
            Book book = _dbContext.Books.FirstOrDefault(e => e.Id == bookinfo.Id);
            if (book != null)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            return book;
        }
        public IEnumerable<Book> getBooks()
        {
            List<Book> books = _dbContext.Books.ToList();
            return books;
        }

        public Author addAuthor(Author authorinfo)
        {
            Author author = _dbContext.Authors.FirstOrDefault(e => e.Id == authorinfo.Id);
            if (author != null)
            {
                _dbContext.Authors.Add(author);
                _dbContext.SaveChanges();
            }
            return author;
        }
        public IEnumerable<Author> getAuthors()
        {
            List<Author> authors = _dbContext.Authors.ToList();
            return authors;
        }
    }
}
