using Newtonsoft.Json;

namespace _1999IdDump.Template;

public class GeneralMap
{
    [JsonProperty("id")] public int id { get; set; }
    [JsonProperty("name")] public string name { get; set; }
    [JsonProperty("nameEng")] public string nameEng { get; set; }
    [JsonProperty("des")] public string des { get; set; }
    [JsonProperty("spine")] public string spine { get; set; }
    [JsonProperty("headIcon")] public string headIcon { get; set; }
}