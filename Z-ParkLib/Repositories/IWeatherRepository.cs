using Z_ParkLib.Model;

namespace Z_ParkLib.repositories
{
    public interface IWeatherRepository
    {
        List<Weather> GetAllWeather();
        
    }
}