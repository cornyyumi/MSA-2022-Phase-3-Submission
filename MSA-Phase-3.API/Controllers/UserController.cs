using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using MSA_Phase_3.Domain.Data;
using MSA_Phase_3.Domain.Models;
using MSA_Phase_3.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace MSA_Phase_3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IConfiguration _configuration;
        private readonly HttpClient _client;
        private readonly IProjRepo _appRepo;

        public UserController(IConfiguration config, IHttpClientFactory clientFactory, IProjRepo repo)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("OpenLib");
            _appRepo = repo;
            _configuration = config;
        }

        [HttpPost("login")]
        public ActionResult Login(UserLogin loginDetail)
        {
            User user = _appRepo.login(loginDetail);
            if (user == null)
            {
                return BadRequest("Invalid credentials");
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
        public ActionResult AddUser(UserLogin user)
        {
            User newUser = _appRepo.register(user);
            return Ok(newUser);
        }

        [Authorize]
        [HttpGet("getAllUsers")]
        public ActionResult GetAlllUsers()
        {
            IEnumerable<User> users = _appRepo.getUsers();
            return Ok(users);
        }

        [HttpGet("getAllBooks")]
        public ActionResult GetAlllBooks()
        {
            IEnumerable<Book> books = _appRepo.getBooks();
            return Ok(books);
        }

        [Authorize]
        [HttpGet("getUserBooks")]
        public ActionResult GetUserBooks()
        {
            User user = _appRepo.getUser(User.FindFirstValue("UserName"));
            if (user != null)
            {
                IEnumerable<UserBook> books = _appRepo.getUserBooks(user.UserName);
            }
            return Ok(user);
        }


        [Authorize]
        [HttpPost("addBookToUser/{isbn}")]
        public ActionResult AddBookToUser(string isbn)
        {
            User user = _appRepo.getUser(User.FindFirstValue("UserName"));
            Book book = _appRepo.getBook(isbn);
            if (book == null)
            {
                book = _appRepo.addBook(isbn);
            }
            UserBook addBook = _appRepo.getUserBook(user, isbn);
            if (addBook == null)
            {
                addBook = _appRepo.addUserBook(user, isbn);
            }
            return Ok(addBook);
        }
    }
}
