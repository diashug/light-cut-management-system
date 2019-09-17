using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LightCutAPIClient
{
    public class UsersClient
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public UsersClient(string baseAddress)
        {
            _httpClient.BaseAddress = new Uri(baseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HttpStatusCode> CreateUser(string name, string username, string password, int roleId)
        {

        }

        public async Task<HttpStatusCode> RemoveUser(string id)
        {
            var response = await _httpClient.DeleteAsync($"/remove/{id}");

            return response.StatusCode;
        }
    }
}
