using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using MSA_Phase_3.Domain.Models;
using MSA_Phase_3.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MSA_Phase_3.Service.Data;
using MSA_Phase_3.Service.Services;

namespace MSA_Phase_3.Service.Services
{
    public class ProjService : IProjService
    {
        private readonly IProjRepo _appRepo;

        public ProjService(IProjRepo repo)
        {
            _appRepo = repo;
        }

        public User login(UserLogin loginDetail)
        {
            User user = _appRepo.login(loginDetail);
            return user;
        }

        public User register(UserLogin user)
        {
            User newUser = _appRepo.register(user);
            return newUser;
        }

        public IEnumerable<User> getUsers()
        {
            IEnumerable<User> users = _appRepo.getUsers();
            return users;
        }

        public IEnumerable<Book> getBooks()
        {
            IEnumerable<Book> books = _appRepo.getBooks();
            return books;
        }

        public User getUser(string username)
        {
            User user = _appRepo.getUser(username);
            return user;
        }

        public IEnumerable<UserBook> getUserBooks(string username)
        {
            IEnumerable<UserBook> books = _appRepo.getUserBooks(username);
            return books;
        }

        public Book getBook(int id)
        {
            Book book = _appRepo.getBook(id);
            return book;

        }

        public Book getBook(string isbn)
        {
            Book book = _appRepo.getBook(isbn);
            return book;
        }

        public Book addBook(string isbn)
        {
            Book book = _appRepo.addBook(isbn);
            return book;

        }
        public UserBook getUserBook(User user, string isbn)
        {
            UserBook addBook = _appRepo.getUserBook(user, isbn);
            return addBook;
        }

        public UserBook addUserBook(User user, string isbn)
        {
            UserBook ub = _appRepo.addUserBook(user, isbn);
            return ub;
        }
    }

}
