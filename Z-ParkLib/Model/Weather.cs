using Newtonsoft.Json;

namespace Z_ParkLib.Model;

//Link til vejr-koder = https://opendatadocs.dmi.govcloud.dk/Data/Meteorological_Observation_Data#MeteorologicalObservationData-Codes

public class Weather
{
    public string Temperature { get; set; }
    public string _rain;
    public string _sun;
    public string _snow;
    
    public string Rain 
    { 
        get { return _rain; }
        set 
        { 
            if (string.IsNullOrWhiteSpace(value) || value.Length != 21) //normal regn koden er 21 fra DMI
            {
                throw new ArgumentException("Det regner");
            }
            _rain = value; 
        } 
    }
    
    public string Sun 
    { 
        get { return _sun; } 
        set 
        { 
            if (string.IsNullOrWhiteSpace(value) || value.Length != 2) 
            {
                throw new ArgumentException("Solen Skinner");
            }
            _sun = value; 
        } 
    }
    
    public string Snow 
    { 
        get { return _snow; } 
        set 
        { 
            if (string.IsNullOrWhiteSpace(value) || value.Length != 22) //snow code fra DMI er 22
            {
                throw new ArgumentException("Det Sner");
            }
            _snow = value;
        } 
    }

    public Weather(string rain, string sun, string snow, string temperature)
    {
        _rain = rain;
        _sun = sun;
        _snow = snow;
        Temperature = temperature;
    }

    public override string ToString()
    {
        return
            $"{nameof(_rain)}: {_rain}, {nameof(_sun)}: {_sun}, {nameof(_snow)}: {_snow}, {nameof(Temperature)}: {Temperature}, {nameof(Rain)}: {Rain}, {nameof(Sun)}: {Sun}, {nameof(Snow)}: {Snow}";
    }
}