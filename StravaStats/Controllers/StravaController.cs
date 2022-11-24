using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using StravaStats.Models;
using Microsoft.Extensions.Options;
using StravaStats.Options;

namespace StravaStats.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StravaController : ControllerBase
    {
        

        private readonly ILogger<StravaController>  _logger;
        private readonly IHttpClientFactory         _httpClientFactory;
        private readonly StravaConfig               _stravaConfig;

        public StravaController(ILogger<StravaController> logger,
            IHttpClientFactory httpClientFactory,
            IOptions<StravaConfig> stravaConfigOptions)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _stravaConfig = stravaConfigOptions.Value;
        }

        [HttpGet("stats")]
        public async Task<ActionResult<YtdAllDto>> Get()
        {
            string accessToken = await GetAccessToken();

            var request = new HttpRequestMessage(HttpMethod.Get,
                                                $"https://www.strava.com/api/v3/athletes/{_stravaConfig.AthleteId}/stats");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {accessToken}");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            var allDto = new YtdAllDto()
            {
                Ride = new RideDto { Count = 0, Distance = 0, MovingTime = 0 },
                Swim = new SwimDto { Count = 0, Distance = 0, MovingTime = 0 },
                Run = new RunDto { Count = 0, Distance = 0, MovingTime = 0 }
            };

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode);
            }
            var stringResponse = await response.Content.ReadAsStringAsync();

            StravaModel root = JsonSerializer.Deserialize<StravaModel>(stringResponse);
            allDto.Ride.Count = root.ytd_ride_totals.count;
            allDto.Ride.Distance = root.ytd_ride_totals.distance;
            allDto.Ride.MovingTime = root.ytd_ride_totals.moving_time;

            allDto.Run.Count = root.ytd_run_totals.count;
            allDto.Run.Distance = root.ytd_run_totals.distance;
            allDto.Run.MovingTime = root.ytd_run_totals.moving_time;

            allDto.Swim.Count = root.ytd_swim_totals.count;
            allDto.Swim.Distance = root.ytd_swim_totals.distance;
            allDto.Swim.MovingTime = root.ytd_swim_totals.moving_time;
            return allDto;


        }


        private async Task<string> GetAccessToken()
        {
            string accessToken = string.Empty;
            var stravaToken = new StravaToken()
            {
                client_id = _stravaConfig.ClientId,
                client_secret = _stravaConfig.ClientSecret,
                refresh_token = _stravaConfig.RefreshToken,
                grant_type = "refresh_token"
            };
            var content = new StringContent(JsonSerializer.Serialize(stravaToken), Encoding.UTF8, "application/json");
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsync("https://www.strava.com/oauth/token", content);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                StravaResponseToken responseToken = JsonSerializer.Deserialize<StravaResponseToken>(stringResponse);
                accessToken = responseToken.access_token;

            }
            return accessToken;
        }
    }
}