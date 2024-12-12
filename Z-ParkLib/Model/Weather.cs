using Newtonsoft.Json;

namespace Z_ParkLib.Model;

//Link til vejr-koder = https://opendatadocs.dmi.govcloud.dk/Data/Meteorological_Observation_Data#MeteorologicalObservationData-Codes

public class Weather
{
    public string Temperature { get; set; }
    public string StationsId { get; set; }

    public Weather(string temperature, string stationsId)
    {
        Temperature = temperature;
        StationsId = stationsId;
    }

    public override string ToString()
    {
        return $"{nameof(Temperature)}: {Temperature}, {nameof(StationsId)}: {StationsId}";
    }
}