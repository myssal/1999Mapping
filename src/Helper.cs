using System.Text.RegularExpressions;

namespace _1999IdDump;

public class Helper
{
    public static async Task<string> DownloadDataAsync(string url, string content)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                Console.WriteLine($"Downloading {content} from: {url}");
                return await client.GetStringAsync(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading from {url}: {ex.Message}");
                return null;
            }
        }
    }
    
    public static void CreateFileWithFolders(string filePath, string content)
    {
        string? directory = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directory))
        {
            Directory.CreateDirectory(directory);
        }
        
        File.WriteAllText(filePath, content);

        Console.WriteLine($"File created at: {filePath}");
    }
    
    public static string ConvertAlternateSpine(string prefabPath, string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(prefabPath))
            return "";
        
        string trimmedPath = prefabPath.Replace("\\", "/"); 
        
        string noPrefab = Regex.Replace(trimmedPath, @"/[^/]+\.prefab$", "");
        return $"{baseUrl}/live2d/roles/{noPrefab}";
    }
    public static string ConvertSpine(string prefabPath, string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(prefabPath))
            return "";
        
        string trimmedPath = prefabPath.Replace("\\", "/"); // Normalize slashes

        if (trimmedPath.Contains("Assets/ZResourcesLib/live2d/roles/"))
        {
            string relativePath = trimmedPath.Replace("Assets/ZResourcesLib", "");
            string noPrefab = Regex.Replace(relativePath, @"/[^/]+\.prefab$", "");
            return $"{baseUrl}{noPrefab}";
        }
        else
        {
            string noPrefab = Regex.Replace(trimmedPath, @"/[^/]+\.prefab$", "");
            return $"{baseUrl}/rolesstory/{noPrefab}";
        }
    }
    
    public static string RemoveAfterSlash(string input, string baseUrl)
    {
        if (string.IsNullOrWhiteSpace(input))
            return "";

        int index = input.IndexOf('/');
        return index >= 0 ? input.Substring(0, index) : input;
    }
}