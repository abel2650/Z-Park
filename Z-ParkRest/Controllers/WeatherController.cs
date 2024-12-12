using Microsoft.AspNetCore.Mvc;

namespace Z_ParkRest.Controllers;

public class WeatherController : ControllerBase
    {
        
        [HttpGet] //Web-API til get metode
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        
        public void WeatherApi (string[] args)
        {
            string apiKey = "f12adcb1-0bcb-4d7b-ad45-b8475b0f12fd"; // API key til ForecastDataAPI (personlig)
            string stationId = "06170";     // Replace with the station ID for Roskilde Lufthavn
            //Bruges som "Endpoint" til at connected til DMIs URL.
            string endpoint = $"https://dmigw.govcloud.dk/v2/metObs/collections/observation/items?stationId={stationId}&api-key={apiKey}";

            //Anbefalet metoder til at indhente API'er.
            using HttpClient client = new HttpClient();
            try
            {
                //Sender en HTTP GET-anmodning til definere Endpoint. Vores endpoint fra før (DMIs. Hjemmeside)
                //HttpResponseMessage venter på Objekt response.Result blokere tråden indtil response fuldført.
                HttpResponseMessage response = client.GetAsync(endpoint).Result;

                //kontrollere statuskoden, hvor mellem 200-299 = succes
                if (response.IsSuccessStatusCode)
                {
                    //Læser indholdet af svaret som en tekststreng.
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"Her er Data: {responseData}");
                }
                else
                {
                    //fejlmeddelelse 
                    Console.WriteLine($"Fejl: {response.StatusCode}");
                }
                    
            }
                
            //fejlmeddelelse 
            catch (Exception ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
            }
        }
    }