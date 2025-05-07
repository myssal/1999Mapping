using Newtonsoft.Json;

namespace _1999IdDump.Data;

public class MonsterSkin
{
    [JsonProperty("id")] public int id { get; set; }
    [JsonProperty("name")] public string name { get; set; }
    [JsonProperty("nameEng")] public string nameEng { get; set; }
    [JsonProperty("des")] public string des { get; set; }
    [JsonProperty("colorbg")] public int colorbg { get; set; }
    [JsonProperty("spine")] public string spine { get; set; }
    [JsonProperty("fight_special")] public int fight_special { get; set; }
    [JsonProperty("flipX")] public int flipX { get; set; }
    [JsonProperty("isFly")] public int isFly { get; set; }
    [JsonProperty("skills")] public string skills { get; set; }
    [JsonProperty("headIcon")] public string headIcon { get; set; }
    [JsonProperty("retangleIcon")] public string retangleIcon { get; set; }
    [JsonProperty("matId")] public int matId { get; set; }
    [JsonProperty("weatherParam")] public int weatherParam { get; set; }
    [JsonProperty("topuiOffset")] public List<double> topuiOffset { get; set; }
    [JsonProperty("focusOffset")] public List<double> focusOffset { get; set; }
    [JsonProperty("showTemplate")] public int showTemplate { get; set; }
    [JsonProperty("noDeadEffect")] public int noDeadEffect { get; set; }
    [JsonProperty("effect")] public string effect { get; set; }
    [JsonProperty("effectHangPoint")] public string effectHangPoint { get; set; }
    [JsonProperty("canHide")] public int canHide { get; set; }
    [JsonProperty("mainBody")] public int mainBody { get; set; }
    [JsonProperty("floatOffset")] public string floatOffset { get; set; }
    [JsonProperty("bossSkillSpeed")] public int bossSkillSpeed { get; set; }
    [JsonProperty("outlineWidth")] public double outlineWidth { get; set; }
    [JsonProperty("clickBoxUnlimit")] public int clickBoxUnlimit { get; set; }
}