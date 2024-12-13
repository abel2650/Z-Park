using Microsoft.AspNetCore.Mvc;
using Z_ParkLib.repositories;

namespace Z_ParkRest.Controllers;

//håndterer HTTP forespørgsler
[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase

//DMI-Swagger metoder = https://dmigw.govcloud.dk/v2/climateData/swagger-ui/index.html?stationId=60170&api-key=5e0123cf-8d85-4ff1-8d57-d6a61a161ea1#/Climate%20data%2020km%20grid%20values/get20kmGridValues

    {
        // Iconfiguration bruges til at indhente vores Appsettings.json med $"{baseUrl}{stationId}{apiKey}";
        private readonly IConfiguration _configuration;
            public WeatherController (IConfiguration configuration)
            {
                //_configuration = gemmer vores objekt, til metoderne igennem /Weather/GetWeatherData
                _configuration = configuration;
            }

            // Gør metoden tilgængelig via en HTTP GET-request
            [HttpGet("GetWeatherData")]
            public async Task<IActionResult> GetWeatherData(string stationId)
            {
                // Configurations filerne er i Appsettings.Json
                string baseUrl = _configuration["DMI:BaseUrl"];
                string apiKey = _configuration["DMI:ApiKey"];

                // Validere stationsID'et
                if (string.IsNullOrEmpty(stationId))
                {
                    //error hvis stationsID'en ikke er angivet.
                    return BadRequest("Station ID is required.");
                }

                // Endpoint URL, for destinationen af data vi gerne vil tilgå
                string endpoint = $"{baseUrl}?stationId={stationId}&api-key={apiKey}";
                
                //https://dmigw.govcloud.dk/v2/metObs/api?stationId=60170&api-key=c40648c9-9bfc-4e59-b799-eda802a602d2

                // her sendes en HTTP forespørgsel.
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        //Vores HTTP GET-request
                        HttpResponseMessage response = await client.GetAsync(endpoint);
                        
                        //hvis APi-kaldet har en kodestatus på 200, er den succesfuldt og føres videre.
                        if (response.IsSuccessStatusCode)
                        {
                            string responseData = await response.Content.ReadAsStringAsync();

                            return Ok(responseData); // Returnere "rå" vejrdata.
                        }
                        
                        //Hvis APi-kaldet ikke er succesfeldt, returneres en fejlbesked fra API'et.
                        return StatusCode((int)response.StatusCode, $"Error: {response.ReasonPhrase}");
                    }
                    
                    //her håndteres andre fejl-connections og returnere en fejlkode 500, med "server fejl".
                    catch (Exception ex)
                    {
                        return StatusCode(500, $"Internal server error: {ex.Message}");
                    }
                }
            }
    }