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
                throw new KeyNotFoundException($"Bruger med nummerplade '{temperature}' ikke fundet.");
            }
            return weather;
        }
        
        public Weather GetWeatherByIdRain (string rain)
        {
            Weather? weather = _weathers.Find(w => w.Rain == rain);
            
            if (weather == null)
            {
                throw new KeyNotFoundException($"hvis du kigger ud så er der '{rain}' udenfor ");
            }
            return weather;
        }
        
        
       public Weather GetWeatherByIdSun (string sun)
        {
            Weather? weather = _weathers.Find(w => w.Sun == sun);
            
            if (weather == null)
            {
                throw new KeyNotFoundException($"hvis du kigger ud så er der '{sun}' udenfor ");
            }
            return weather;
        }
        
        public Weather GetWeatherByIdSnow (string snow)
        {
            Weather? weather = _weathers.Find(w => w.Snow == snow);
            
            if (weather == null)
            {
                throw new KeyNotFoundException($"hvis du kigger ud så er der '{snow}' udenfor ");
            }
            return weather;
        }
        
    }