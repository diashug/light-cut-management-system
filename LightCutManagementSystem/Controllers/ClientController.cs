using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using LightCut.Models;
using LightCut.Data.Repository;

namespace LightCutManagement.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientRepository _clientRepository;
        private IConfiguration _config;

        public ClientController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API

        [HttpGet]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(_clientRepository.GetAll());
        }

        #endregion

        [HttpPost]
        public async Task<Dictionary<string, object>> Create(string name, int vatNumber, int phoneNumber,
                                                             string email, string address, string postalCode,
                                                             string locality, string district)
        {
            var client = new Client()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = name,
                VatNumber = vatNumber,
                PhoneNumber = phoneNumber,
                Email = email,
                Address = address,
                PostalCode = postalCode,
                Locality = locality,
                District = district
            };

            var content = JsonConvert.SerializeObject(client);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(_baseUrl + "/clients", byteContent);

            var data = new Dictionary<string, object>();

            if (response.StatusCode.Equals(HttpStatusCode.Accepted))
            {
                data.Add("error", false);
                data.Add("message", "Novo cliente registado com sucesso.");
            }
            else
            {
                data.Add("error", true);
                data.Add("message", "Não foi possível registar o novo cliente.");
            }

            return data;
        }

        [HttpPut]
        public async Task<Dictionary<string, object>> Update(string id, string name, int vatNumber,
                                                             int phoneNumber, string email, string address,
                                                             string postalCode, string locality, string district)
        {
            var client = new Client()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = name,
                VatNumber = vatNumber,
                PhoneNumber = phoneNumber,
                Email = email,
                Address = address,
                PostalCode = postalCode,
                Locality = locality,
                District = district
            };

            var content = JsonConvert.SerializeObject(client);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PutAsync(string.Format(_baseUrl + "/clients/{0}", id), byteContent);

            var data = new Dictionary<string, object>();

            if (response.StatusCode.Equals(HttpStatusCode.Accepted))
            {
                data.Add("error", false);
                data.Add("message", "A informação do cliente foi actualizada com sucesso.");
            }
            else
            {
                data.Add("error", true);
                data.Add("message", "Não foi possível actualizar a informação do cliente.");
            }

            return data;
        }

        [HttpDelete]
        public async Task<Dictionary<string, object>> Remove(string id)
        {
            var response = await _httpClient.DeleteAsync(string.Format(_baseUrl + "/clients/{0}", id));

            var data = new Dictionary<string, object>();

            if (response.StatusCode.Equals(HttpStatusCode.Accepted))
            {
                data.Add("error", false);
                data.Add("message", "A informação do cliente foi removida com sucesso.");
            }
            else
            {
                data.Add("error", true);
                data.Add("message", "Não foi possível remover a informação do cliente.");
            }

            return data;
        }
    }
}