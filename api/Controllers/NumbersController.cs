using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using api.Dto;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class NumbersController : Controller
    {
        [HttpGet("{number}")]
        public async Task<NumberResponse> GetNumberAsync(int number)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("http://numbersapi.com/" + number + "?json");
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NumberResponse>(result);
        }
    }
}
