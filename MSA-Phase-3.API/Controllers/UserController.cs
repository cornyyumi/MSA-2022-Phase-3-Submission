using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MSA_Phase_3.Domain.Data;
using MSA_Phase_3.Domain.Models;
namespace MSA_Phase_3.API.Controllers
{
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

        [HttpPost("AddUser")]
        public ActionResult AddUser(string username)
        {
            User user = _appRepo.addUser(username);
            return Ok(user);
        }

        [HttpPost("AddBook")]
        public ActionResult AddBookToUser(Book book)
        {
            Book addBook = _appRepo.addBook(book);
            return Ok();
        }
    }
}
