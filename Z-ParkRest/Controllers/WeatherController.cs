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

                // Validate stationId
                if (string.IsNullOrEmpty(stationId))
                {
                    return BadRequest("Station ID is required.");
                }

                // Construct the endpoint URL
                string endpoint = $"{baseUrl}?stationId={stationId}&api-key={apiKey}";

                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        // Send the HTTP GET request
                        HttpResponseMessage response = await client.GetAsync(endpoint);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync();

                            // Optional: Deserialize the JSON response to a C# object for structured access
                            // var weatherData = JsonConvert.DeserializeObject<WeatherDataModel>(responseData);

                            return Ok(responseData); // Return raw or deserialized data
                        }
                        else
                        {
                            return StatusCode((int)response.StatusCode, $"Error: {response.ReasonPhrase}");
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, $"Internal server error: {ex.Message}");
                    }
                }
            }
    }
    
        
        // /*public void WeatherApi (string[] args)
        // {
        //     string apiKey = "f12adcb1-0bcb-4d7b-ad45-b8475b0f12fd"; // API-key til ForecastDataAPI (personlig)
        //     string stationId = "06170";     // stations-id til Roskilde Lufthavn
        //     string baseUrl = "https://dmigw.govcloud.dk/v2/metObs/collections/observation/items"; //
        //     
        //     //Bruges som "Endpoint" til at connected til DMIs URL.
        //     /*string endpoint = $"https://dmigw.govcloud.dk/v2/metObs/collections/observation/items?stationId={stationId}&api-key={apiKey}";*/
        //     string endpoint = $"{baseUrl}?stationId={stationId}&api-key={apiKey}";
        //
        //     //Anbefalet metoder til at indhente API'er.
        //     using HttpClient client = new HttpClient();
        //     try
        //     {
        //         //Sender en HTTP GET-anmodning til at definere Endpoint. Vores endpoint fra før (DMIs. Hjemmeside)
        //         //HttpResponseMessage venter på Objekt response.Result blokere tråden indtil response fuldført.
        //         HttpResponseMessage response = client.GetAsync(endpoint).Result;
        //
        //         //kontrollere statuskoden, hvor mellem 200-299 = succes
        //         if (response.IsSuccessStatusCode)
        //         {
        //             //Læser indholdet af svaret som en tekststreng.
        //             string responseData = response.Content.ReadAsStringAsync().Result;
        //             Console.WriteLine($"Her er Data: {responseData}");
        //         }
        //         else
        //         {
        //             //fejlmeddelelse 
        //             Console.WriteLine($"Fejl: {response.StatusCode}");
        //         }
        //             
        //     }
        //         
        //     //fejlmeddelelse 
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Fejl: {ex.Message}");
        //     }*/
        // }