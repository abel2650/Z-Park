using Z_ParkLib.Model;

namespace Z_ParkLib.repositories
{
    public interface IWeatherRepository
    {
        List<Weather> GetAllWeather();

        Weather GetWeatherById(string temperature);

        Weather GetWeatherByIdRain(string rain);

        Weather GetWeatherByIdSun(string sun);

        Weather GetWeatherByIdSnow(string snow);
    }
}