using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using TrelloIntegrationExample.Models;

namespace TrelloIntegrationExample.Controllers
{
    public class TrelloController : Controller
    {
        private string _apiKey = Environment.GetEnvironmentVariable("TRELLO_API_KEY");
        private string _token = Environment.GetEnvironmentVariable("TRELLO_TOKEN");

        private readonly HttpClient _httpClient;
        public TrelloController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.trello.com/1/")
            };
        }

        public async Task<IActionResult> Index()
        {
            var model = await TrelloGetRequest<TrelloUser>("members/me?boards=all&organizations=all&");

            return View("Index", model);
        }

        public async Task<IActionResult> DetalhesBoard(string id)
        {
            var model = await TrelloGetRequest<TrelloBoard>($"boards/{id}?lists=open&cards=all&");

            return View("Board", model);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCard(TrelloCard card)
        {
            var model = await TrelloPostRequest<TrelloCard>(
                $"card/?name={Uri.EscapeDataString(card.Name)}&idList={card.IdList}&");

            return RedirectToAction("DetalhesBoard", new {id = model.IdBoard});
        }

        private async Task<T> TrelloGetRequest<T>(string url)
        {
            var request = await _httpClient.GetAsync($"{url}key={_apiKey}&token={_token}");

            if (!request.IsSuccessStatusCode)
                throw new Exception("Deu errado...");

            var model = await request.Content.ReadAsAsync<T>();

            return model;
        }

        private async Task<T> TrelloPostRequest<T>(string url)
        {
            var request = await _httpClient.PostAsync($"{url}key={_apiKey}&token={_token}",
                new StringContent(JsonConvert.SerializeObject(new {}),Encoding.UTF8, "application/json"));

            if (!request.IsSuccessStatusCode)
                throw new Exception("Deu errado...");

            var model = await request.Content.ReadAsAsync<T>();

            return model;
        }
    }
}
