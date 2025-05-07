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
}