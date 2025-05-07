using Newtonsoft.Json;

namespace _1999IdDump.Data;

public class Character
{
    [JsonProperty("id")] public int id { get; set; }
    [JsonProperty("name")] public string name { get; set; }
    [JsonProperty("initials")] public string initials { get; set; }
    [JsonProperty("skinId")] public int skinId { get; set; }
    [JsonProperty("career")] public int career { get; set; }
    [JsonProperty("rare")] public int rare { get; set; }
    [JsonProperty("dmgType")] public int dmgType { get; set; }
    [JsonProperty("gender")] public int gender { get; set; }
    [JsonProperty("battleTag")] public string battleTag { get; set; }
    [JsonProperty("equipRec")] public string equipRec { get; set; }
    [JsonProperty("rank")] public int rank { get; set; }
    [JsonProperty("uniqueSkill_point")] public string uniqueSkill_point { get; set; }
    [JsonProperty("powerMax")] public string powerMax { get; set; }
    [JsonProperty("ai")] public int ai { get; set; }
    [JsonProperty("firstItem")] public string firstItem { get; set; }
    [JsonProperty("duplicateItem")] public string duplicateItem { get; set; }
    [JsonProperty("duplicateItem2")] public string duplicateItem2 { get; set; }
    [JsonProperty("skill")] public string skill { get; set; }
    [JsonProperty("exSkill")] public int exSkill { get; set; }
    [JsonProperty("resistance")] public int resistance { get; set; }
    [JsonProperty("school")] public int school { get; set; }
    [JsonProperty("characterTag")] public string characterTag { get; set; }
    [JsonProperty("nameEng")] public string nameEng { get; set; }
    [JsonProperty("signature")] public string signature { get; set; }
    [JsonProperty("photoFrameBg")] public int photoFrameBg { get; set; }
    [JsonProperty("isOnline")] public string isOnline { get; set; }
    [JsonProperty("heroType")] public int heroType { get; set; }
    [JsonProperty("actor")] public string actor { get; set; }
    [JsonProperty("roleBirthday")] public string roleBirthday { get; set; }
    [JsonProperty("trust")] public int trust { get; set; }
    [JsonProperty("birthdayBonus")] public string birthdayBonus { get; set; }
    [JsonProperty("desc")] public string desc { get; set; }
    [JsonProperty("useDesc")] public string useDesc { get; set; }
    [JsonProperty("desc2")] public string desc2 { get; set; }
    [JsonProperty("mvskinId")] public int mvskinId { get; set; }
}