using _1999IdDump;
using _1999IdDump.Data;
using _1999IdDump.Template;
using Newtonsoft.Json;

public class IdDump {
    private const string baseUrl = "https://github.com/myssal/Reverse-1999-CN-Asset";
    private const string cubismUri = @"live2d/roles";
    private const string spineUri = @"roles";
    
    private const string monsterSkinUrl = "https://raw.githubusercontent.com/St-Pavlov-Foundation/re1999-data/main/data/json/monster_skin.json";
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
        var arcanistMap = new List<ArcanistMap>();
        
        foreach (var character in characters)
        {
            var characterSkins = skins.Where(s => s.characterId == character.id).ToList();
            var live2dList = new List<Live2d>();
            
            foreach (var skin in characterSkins)
            {
                live2dList.Add(new Live2d
                {
                    id = skin.id,
                    name = skin.name,
                    nameEng = skin.nameEng,
                    des = skin.des,
                    characterSkin = skin.characterSkin,
                    characterSkinNameEng = skin.characterSkinNameEng,
                    skinDescription = skin.skinDescription,
                    live2d = skin.live2d,
                    spine = skin.spine,
                    alternateSpine = skin.alternateSpine
                });
            }
            
            arcanistMap.Add(new ArcanistMap
            {
                id = character.id,
                name = character.name,
                nameEng = character.nameEng,
                roleBirthday = character.roleBirthday,
                signature = character.signature,
                live2d = live2dList
            });
        }
        
        string json = JsonConvert.SerializeObject(arcanistMap, Formatting.Indented);
        Helper.CreateFileWithFolders(outputFile, json);
    }

    public void GenerateGeneralMap(string outputFile)
    {
        var generalMap = new List<GeneralMap>();
        
        foreach (var monsterSkin in monsterSkins)
        {
            generalMap.Add(new GeneralMap
            {
                id = monsterSkin.id,
                name = monsterSkin.name,
                nameEng = monsterSkin.nameEng,
                des = monsterSkin.des,
                spine = monsterSkin.spine,
                headIcon = monsterSkin.headIcon
            });
        }
        
        string json = JsonConvert.SerializeObject(generalMap, Formatting.Indented);
        Helper.CreateFileWithFolders(outputFile, json);
    }
    
}