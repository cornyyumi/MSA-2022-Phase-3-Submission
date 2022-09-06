using MSA_Phase_3.Domain.Models;

namespace MSA_Phase_3.Domain.Data
{
    public interface IProjRepo
    {
        User addUser(User user);
        IEnumerable<User> getUsers();

        Book addBook(Book root);
        IEnumerable<Book> getBooks();

        Author addAuthor(Author author);
        IEnumerable<Author> getAuthors();
    }
}
