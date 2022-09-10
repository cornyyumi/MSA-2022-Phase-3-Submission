using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSA_Phase_3.Service.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _client;
        public BookService (IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("OpenLib");
        }
        public async Task<bool> IsRealBook(string isbn)
        {
            string url = "isbn/"+isbn + ".json";
            var response = await _client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false;
            }
            return true;
        }
    }
}
