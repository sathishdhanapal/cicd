using System;
using System.Net.Http;
using System.Threading.Tasks;
using api.Dto;
using Newtonsoft.Json;
using Xunit;

namespace test
{

    public class GetByNumber : ApiControllerTestBase
    {
        private readonly HttpClient _client;
        public GetByNumber()
        {
            _client = base.GetClient();            
        }

        [Theory]
        [InlineData("numbers")]
        public async Task ReturnsTextForTheNumber43(string controllerName)
        {
            var response = await _client.GetAsync($"/api/{controllerName}/43");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NumberResponse>(stringResponse);

            Assert.Equal(42, result.Number);
            Assert.NotEmpty(result.Text);
        }
    }
}