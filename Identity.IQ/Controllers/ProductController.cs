using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.IQApi.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Identity.IQ.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> productsList = new();
            HttpClient httpClient = new HttpClient();
            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:7000");
            if (disco.IsError)
            {
                //Hata Var Log Yap
            }

            ClientCredentialsTokenRequest credentialsTokenRequest = new()
            {
                ClientId = _configuration["Client:ClientId"],
                ClientSecret = _configuration["Client:ClientSecret"],
                Address = disco.TokenEndpoint
                    
            };
            var token = await httpClient.RequestClientCredentialsTokenAsync(credentialsTokenRequest);
            httpClient.SetBearerToken(token.AccessToken);
            var response = await httpClient.GetAsync("https://localhost:7024/api/Product/GetProducts");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                productsList = JsonConvert.DeserializeObject<List<Product>>(content);
            }
            return View(productsList);
        }
    }
}