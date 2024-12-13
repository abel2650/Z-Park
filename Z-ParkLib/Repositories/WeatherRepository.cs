using Z_ParkLib.Model;

namespace Z_ParkLib.repositories;

public class WeatherRepository : IWeatherRepository
    {
        private readonly List<Weather> _weathers;
        
        public List<Weather> GetAllWeather()
        {
            return new List<Weather>(_weathers);
        }
        
        public Weather GetWeatherById(string temperature)
        {
            Weather? weather = _weathers.Find(u => u.Temperature == temperature);

            if (weather == null)
            {
                throw new KeyNotFoundException($"vejret '{temperature}' ikke fundet.");
            }
            return weather;
        }
        
    }