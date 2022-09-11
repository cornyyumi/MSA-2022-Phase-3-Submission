using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using MSA_Phase_3.Domain.Models;
using MSA_Phase_3.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MSA_Phase_3.Service.Data;
using MSA_Phase_3.Service.Services;
using FluentValidation;
using FluentValidation.Results;
namespace MSA_Phase_3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IConfiguration _configuration;
        private readonly IProjService _projService;
        private readonly IBookService _bookService;
        private IValidator<UserLogin> _validator;



        public UserController(IValidator<UserLogin> validator,IConfiguration config, IProjService projService, IBookService bookService)
        {
            _configuration = config;
            _projService = projService;
            _bookService = bookService;
            _validator = validator;
        }

        [HttpPost("login")]
        public ActionResult Login(UserLogin loginDetail)
        {
            var user = _projService.login(loginDetail);
            if (user == null)
            {
                return BadRequest("Invalid wcredentials");
            }
            var claims = new[] {
                        new Claim("UserName", user.UserName)
                    };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserLogin user)
        {
            ValidationResult results = _validator.Validate(user);
            if (!results.IsValid)
            {
                return BadRequest(results.ToString("~"));
            }

            User newUser = _projService.register(user);
            if (newUser == null)
            {
                return BadRequest("Invalid credentials");
            }
            return Ok(newUser);
        }

        [Authorize]
        [HttpGet("getAllUsers")]
        public ActionResult GetAlllUsers()
        {
            IEnumerable<User> users = _projService.getUsers();
            return Ok(users);
        }

        [HttpGet("getAllBooks")]
        public ActionResult GetAlllBooks()
        {
            IEnumerable<Book> books = _projService.getBooks();
            List<BookDTO> BookDTOs = new List<BookDTO>();
            foreach (Book book in books)
            {
                BookDTOs.Add(new BookDTO
                {
                    Isbn_13 = book.Isbn_13

                });
            }
            return Ok(BookDTOs);
        }

        [Authorize]
        [HttpGet("getUserBooks")]
        public ActionResult GetUserBooks()
        {
            User user = _projService.getUser(User.FindFirstValue("UserName"));
            IEnumerable<UserBook> books = _projService.getUserBooks(user.UserName);
            List<BookDTO> BookDTOs = new List<BookDTO>();
            foreach (UserBook book in books)
            {
                Book book1 = _projService.getBook(book.BookId);
                BookDTOs.Add(new BookDTO
                {
                    Isbn_13 = book1.Isbn_13

                });
            }

            return Ok(BookDTOs);
        }


        [Authorize]
        [HttpPost("addBookToUser/{isbn}")]
        public ActionResult AddBookToUser(string isbn)
        {
            User user = _projService.getUser(User.FindFirstValue("UserName"));
            Book book = _projService.getBook(isbn);
            if (!_bookService.IsRealBook(isbn).Result)
            {
                return BadRequest("Book with corresponding isbn does not exist");
            }
            if (book == null)
            {
                book = _projService.addBook(isbn);
            }
            UserBook addBook = _projService.getUserBook(user, isbn);
            if (addBook == null)
            {
                addBook = _projService.addUserBook(user, isbn);
            }
            
            return Ok(new BookDTO
            {
                Isbn_13 = isbn
            });
        }
    }
}
