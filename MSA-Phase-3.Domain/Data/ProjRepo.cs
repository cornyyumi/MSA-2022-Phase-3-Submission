using MSA_Phase_3.Domain.Models;
using MSA_Phase_3.Domain.Dto;

namespace MSA_Phase_3.Domain.Data
{
    public class ProjRepo : IProjRepo
    {
        private readonly ProjDbContext _dbContext;
        public ProjRepo(ProjDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public User addUser(UserDTO user)
        {

            User newuser = _dbContext.Users.FirstOrDefault(x => x.UserName == user.UserName);
            if (newuser == null)
            {
                newuser = new User { UserName = user.UserName };
                _dbContext.Users.Add(newuser);
                _dbContext.SaveChanges();
            }
            return newuser;
        }

        public IEnumerable<User> getUsers()
        {
            List<User> users = _dbContext.Users.ToList();
            return users;

        }
        public Book addBook(Book bookinfo)
        {
            Book book = _dbContext.Books.FirstOrDefault(e => e.Id == bookinfo.Id);
            if (book == null)
            {
                Book newBook = new Book {
                    title = bookinfo.title,
                    description = bookinfo.description,
                    Isbn_13 = bookinfo.Isbn_13,
                    fileImageURL = bookinfo.fileImageURL
                };
                _dbContext.Books.Add(newBook);
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
