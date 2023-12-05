using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoogleTranslateController : Controller
    {

        private readonly ILogger<GoogleTranslateController> _logger;
        public GoogleTranslateController(ILogger<GoogleTranslateController> logger)
        {
            _logger = logger;
        }

        [HttpGet("translate_google")]
        public async Task<IActionResult> translate_google()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
    {
        { "X-RapidAPI-Key", "SIGN-UP-FOR-KEY" },
        { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
    },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
    {
        { "q", "Hello, world!" },
        { "target", "es" },
        { "source", "en" },
    }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
            return Json("");
        }
    }
}
