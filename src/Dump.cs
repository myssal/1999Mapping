using System.Text.RegularExpressions;
using _1999IdDump;
using _1999IdDump.Data;
using _1999IdDump.Template;
using Newtonsoft.Json;

public class IdDump {
    private const string baseUrl = "https://github.com/myssal/Reverse-1999-CN-Asset/tree/master";
    private const string cubismUri = @"live2d/roles";
    private const string spineUri = @"roles";
    
    private const string monsterSkinUrl = "https://raw.githubusercontent.com/St-Pavlov-Foundation/re1999-data/main/data/json/monster_skin.json";
    private const string skinUrl = "https://raw.githubusercontent.com/St-Pavlov-Foundation/re1999-data/main/data/json/skin.json";
    private const string characterUrl = "https://raw.githubusercontent.com/St-Pavlov-Foundation/re1999-data/main/data/json/character.json";
    private const string heroParamUrl = "https://raw.githubusercontent.com/St-Pavlov-Foundation/re1999-data/main/data/lua/modules/configs/story/lua_story_heroparam.lua";
    
    
    public List<MonsterSkin> monsterSkins{ get; set; } = new List<MonsterSkin>();
    public List<Skin> skins { get; set; } = new List<Skin>();
    public List<Character> characters { get; set; } = new List<Character>();
    public string heroParamData { get; set; }
    public IdDump()
    {
        var monsterTask = Helper.DownloadDataAsync(monsterSkinUrl, "monster skin data");
        var skinTask = Helper.DownloadDataAsync(skinUrl, "arcanist skin data");
        var characterTask = Helper.DownloadDataAsync(characterUrl, "arcanist data");
        var heroParamTask = Helper.DownloadDataAsync(heroParamUrl, "hero_param data");
        
        Task.WaitAll(monsterTask, skinTask, characterTask, heroParamTask);
        
        string monsterSkinData = monsterTask.Result;
        string skinData = skinTask.Result;
        string characterData = characterTask.Result;
        heroParamData = heroParamTask.Result;
        
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
                    cubism = $"{baseUrl}/roles/{RemoveAfterSlash(skin.spine)}",
                    spine = $"{baseUrl}/live2d/roles/{RemoveAfterSlash(skin.cubism)}",
                    alternateSpine = $"{baseUrl}/roles/{RemoveAfterSlash(skin.alternateSpine)}"
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
        File.WriteAllText(outputFile, json);
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
                spine = $"{baseUrl}/roles/{RemoveAfterSlash(monsterSkin.spine)}",
                headIcon = $"{baseUrl}/singlebg/headicon_monster/{monsterSkin.headIcon}.png"
            });
           }
        
        string json = JsonConvert.SerializeObject(generalMap, Formatting.Indented);
        File.WriteAllText(outputFile, json);
    }

    public void GenerateStorySpriteMap(string outputFile)
    {
        var result = new List<StorySpriteMap>();

        var matches = Regex.Matches(heroParamData, @"\{([^}]*)\}");

        foreach (Match match in matches)
        {
            var values = match.Groups[1].Value
                .Split(',')
                .Select(s => s.Trim().Trim('"'))
                .ToList();

            if (values.Count < 16)
                continue;
            result.Add(new StorySpriteMap
            {
                id = int.TryParse(values[0], out var idVal) ? idVal : 0,
                nameEng = values[4],
                name = values[3],
                spine = ConvertSpine(values[12]),
                alternateSpine = ConvertAlternateSpine(values[13]),
                desc = values[15]
            });
        }
        
        string json = JsonConvert.SerializeObject(result, Formatting.Indented);
        File.WriteAllText(outputFile, json);
    }

    public static string ConvertAlternateSpine(string prefabPath)
    {
        if (string.IsNullOrWhiteSpace(prefabPath))
            return "";
        
        string trimmedPath = prefabPath.Replace("\\", "/"); // Normalize slashes
        
        // Just remove trailing .prefab and prepend alt base URL
        string noPrefab = Regex.Replace(trimmedPath, @"/[^/]+\.prefab$", "");
        return $"{baseUrl}/live2d/roles/{noPrefab}";
    }
    public static string ConvertSpine(string prefabPath)
    {
        if (string.IsNullOrWhiteSpace(prefabPath))
            return "";
        
        string trimmedPath = prefabPath.Replace("\\", "/"); // Normalize slashes

        if (trimmedPath.Contains("Assets/ZResourcesLib/live2d/roles/"))
        {
            // Remove "Assets/ZResourcesLib"
            string relativePath = trimmedPath.Replace("Assets/ZResourcesLib", "");
            string noPrefab = Regex.Replace(relativePath, @"/[^/]+\.prefab$", "");
            return $"{baseUrl}{noPrefab}";
        }
        else
        {
            // Just remove trailing .prefab and prepend alt base URL
            string noPrefab = Regex.Replace(trimmedPath, @"/[^/]+\.prefab$", "");
            return $"{baseUrl}/rolesstory/{noPrefab}";
        }
    }
    
    public static string RemoveAfterSlash(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "";

        int index = input.IndexOf('/');
        return index >= 0 ? input.Substring(0, index) : input;
    }
}