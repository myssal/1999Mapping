using Newtonsoft.Json;

namespace _1999IdDump.Template;

public class ArcanistMap
{
    [JsonProperty("id")] public int id { get; set; }
    [JsonProperty("name")] public string name { get; set; }
    [JsonProperty("nameEng")] public string nameEng { get; set; }
    [JsonProperty("roleBirthday")] public string roleBirthday { get; set; }
    [JsonProperty("signature")] public string signature { get; set; }
    [JsonProperty("live2d")] public List<Live2d> live2d { get; set; }
}

public class Live2d
{
    [JsonProperty("id")] public int id { get; set; }
    [JsonProperty("name")] public string name { get; set; }
    [JsonProperty("nameEng")] public string nameEng { get; set; }
    [JsonProperty("des")] public string des { get; set; }
    [JsonProperty("characterSkin")] public string characterSkin { get; set; }
    [JsonProperty("characterSkinNameEng")] public string characterSkinNameEng { get; set; }
    [JsonProperty("skinDescription")] public string skinDescription { get; set; }
    [JsonProperty("cubism")] public string cubism { get; set; }
    [JsonProperty("spine")] public string spine { get; set; }
    [JsonProperty("alternateSpine")] public string alternateSpine { get; set; }
}