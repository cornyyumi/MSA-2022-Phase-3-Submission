using MSA_Phase_3.Domain.Models;
using MSA_Phase_3.Domain.Dto;

namespace MSA_Phase_3.Service.Data
{
    public class ProjRepo : IProjRepo
    {
        private readonly ProjDbContext _dbContext;
        public ProjRepo(ProjDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User login(UserLogin user)
        {
            User loginUser = _dbContext.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            return loginUser;
        }
        public User register(UserLogin user)
        {

            User newuser = _dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (newuser == null)
            {
                newuser = new User { UserName = user.UserName, Password = user.Password };
                _dbContext.Users.Add(newuser);
                _dbContext.SaveChanges();
            }
            return newuser;
        }
        public User getUser(string username)
        {
            User user = _dbContext.Users.FirstOrDefault(e => e.UserName == username);
            return user;
        }

        public IEnumerable<User> getUsers()
        {
            List<User> users = _dbContext.Users.ToList();
            return users;

        }
        public Book addBook(string isbn)
        {
            Book book = _dbContext.Books.FirstOrDefault(e => e.Isbn_13 == isbn);
            if (book == null)
            {
                Book newBook = new Book
                {
                    Isbn_13 = isbn
                };
                _dbContext.Books.Add(newBook);
                _dbContext.SaveChanges();
            }
            return book;
        }

        public Book getBook(int id)
        {
            Book book = _dbContext.Books.FirstOrDefault(e => e.Id == id);
            return book;
        }

        public Book getBook(string isbn)
        {
            Book book = _dbContext.Books.FirstOrDefault(e => e.Isbn_13 == isbn);
            return book;
        }

        public IEnumerable<Book> getBooks()
        {
            List<Book> books = _dbContext.Books.ToList();
            return books;
        }

        public IEnumerable<UserBook> getUserBooks(string username)
        {
            List<UserBook> books = _dbContext.UserBooks.Where(e => e.UserName == username).ToList();
            return books;
        }

        public UserBook getUserBook(User user, string isbn)
        {
            UserBook book = _dbContext.UserBooks.FirstOrDefault(e => e.UserName == user.UserName && e.Book.Isbn_13 == isbn);
            return book;
        }

        public UserBook addUserBook(User user, string isbn)
        {
            Book book = _dbContext.Books.FirstOrDefault(e => e.Isbn_13 == isbn);
            UserBook ub = new UserBook
            {
                UserName = user.UserName,
                User = user,
                BookId = book.Id,
                Book = book
            };
            _dbContext.UserBooks.Add(ub);
            _dbContext.SaveChanges();
            return ub;

        }
    }
}
