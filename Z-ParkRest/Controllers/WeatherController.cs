using Microsoft.AspNetCore.Mvc;
using Z_ParkLib.repositories;

namespace Z_ParkRest.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
    {
        private readonly IConfiguration _configuration;
            public WeatherController (IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpGet("GetWeatherData")]
            public async Task<IActionResult> GetWeatherData(string stationId)
            {
                // Configurations filerne er i Appsettings.Json
                string baseUrl = _configuration["DMI:BaseUrl"];
                string apiKey = _configuration["DMI:ApiKey"];

                // Validere stationsID'et
                if (string.IsNullOrEmpty(stationId))
                {
                    return BadRequest("Station ID is required.");
                }

                // Endpoint URL, for destinationen af data vi gerne vil tilgå
                string endpoint = $"{baseUrl}?stationId={stationId}&api-key={apiKey}";
                
                //https://dmigw.govcloud.dk/v2/metObs/api?stationId=60170&api-key=c40648c9-9bfc-4e59-b799-eda802a602d2

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // vores HTTP GET-request
                        HttpResponseMessage response = await client.GetAsync(endpoint);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync();

                            return Ok(responseData); // Returnere "rå" vejrdata.
                        }

                        return StatusCode((int)response.StatusCode, $"Error: {response.ReasonPhrase}");
                    }
                    
                    catch (Exception ex)
                    {
                        return StatusCode(500, $"Internal server error: {ex.Message}");
                    }
                }
            }
    }