using _1999IdDump;
using _1999IdDump.Data;
using Newtonsoft.Json;

public class IdDump {
    private const string baseUrl = "https://github.com/myssal/Reverse-1999-CN-Asset";

    private const string monsterSkinUrl = "https://raw.githubusercontent.com/St-Pavlov-Foundation/re1999-data/main/data/json/skin.json";
    private const string skinUrl = "https://raw.githubusercontent.com/St-Pavlov-Foundation/re1999-data/main/data/json/skin.json";
    private const string characterUrl = "https://raw.githubusercontent.com/St-Pavlov-Foundation/re1999-data/main/data/json/character.json";
    
    
    public List<MonsterSkin> monsterSkins{ get; set; } = new List<MonsterSkin>();
    public List<Skin> skins { get; set; } = new List<Skin>();
    public List<Character> characters { get; set; } = new List<Character>();
    
    public IdDump()
    {
        var monsterTask = Helper.DownloadDataAsync(monsterSkinUrl, "monster skin data");
        var skinTask = Helper.DownloadDataAsync(skinUrl, "arcanist skin data");
        var characterTask = Helper.DownloadDataAsync(characterUrl, "arcanist data");
        Task.WaitAll(monsterTask, skinTask, characterTask);
        
        string monsterSkinData = monsterTask.Result;
        string skinData = skinTask.Result;
        string characterData = characterTask.Result;
        
        if (monsterSkinData != null)
            monsterSkins = JsonConvert.DeserializeObject<List<MonsterSkin>>(monsterSkinData);
        else
            Console.WriteLine("Failed to get monster skin data.");
        
        if (skinData != null)
            skins = JsonConvert.DeserializeObject<List<Skin>>(skinData);
        else
            Console.WriteLine("Failed to get skin data.");
        
        if (characterData != null)
            characters = JsonConvert.DeserializeObject<List<Character>>(characterData);
        else
            Console.WriteLine("Failed to get character data.");
    }

    public void GenerateArcanistMap(string outputFile)
    {
        
        
    }
    
    
}