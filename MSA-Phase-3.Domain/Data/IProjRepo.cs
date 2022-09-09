using MSA_Phase_3.Domain.Models;
using MSA_Phase_3.Domain.Dto;

namespace MSA_Phase_3.Domain.Data
{
    public interface IProjRepo
    {
        User addUser(UserDTO user);
        IEnumerable<User> getUsers();

        Book addBook(string isbn);
        IEnumerable<Book> getBooks();

        Author addAuthor(Author author);
        IEnumerable<Author> getAuthors();
    }
}
