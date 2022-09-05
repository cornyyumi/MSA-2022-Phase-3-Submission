using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MSA_Phase_3.Domain.Data;
using MSA_Phase_3.Domain.Models;
namespace MSA_Phase_3.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly HttpClient _client;
        private readonly IProjRepo _appRepo;

        public UserController(IHttpClientFactory clientFactory, IProjRepo repo)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("OpenLib");
            _appRepo = repo;
        }

        [HttpGet("GetAlllUsers")]
        public ActionResult GetAlllUsers()
        {
            IEnumerable<User> users = _appRepo.getUsers();
            return Ok(users);
        }

        [HttpPost("AddUser")]
        public ActionResult AddUser(string username)
        {
            User user = _appRepo.addUser(username);
            return Ok(user);
        }

        [HttpGet("GetAlllBooks")]
        public ActionResult GetAlllBooks()
        {
            IEnumerable<Book> books = _appRepo.getBooks();
            return Ok(books);
        }

        [HttpPost("AddBook")]
        public ActionResult AddBookToUser(Book book)
        {
            Book addBook = _appRepo.addBook(book);
            return Ok();
        }
    }
}
