using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRandomStringHolder randomStringService;
        private readonly IRandomStringHolder randomStringService2;

        public WeatherForecastController(IRandomStringHolder randomStringService, IRandomStringHolder randomStringService2)
        {
            this.randomStringService = randomStringService;
            this.randomStringService2 = randomStringService2;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return randomStringService.RandomString + "  -  " + randomStringService2.RandomString;
        }

        [HttpGet("makeRequest")]
        public async Task<string> MakeRequest()
        {
            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetAsync("https://www.google.com/");
                return await result.Content.ReadAsStringAsync();
            } 
        }
    }
}
