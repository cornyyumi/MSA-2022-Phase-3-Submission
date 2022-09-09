using MSA_Phase_3.Domain.Models;
using MSA_Phase_3.Domain.Dto;

namespace MSA_Phase_3.Domain.Data
{
    public interface IProjRepo
    {
        User login(UserLogin user);
        User register(UserLogin user);
        User getUser(string username);
        IEnumerable<User> getUsers();

        Book addBook(string isbn);
        Book getBook(int id);
        Book getBook(string isbn);
        IEnumerable<Book> getBooks();
        UserBook getUserBook(User user, string isbn);
        IEnumerable<UserBook> getUserBooks(string username);
        UserBook addUserBook(User user, string isbn);
    }
}
