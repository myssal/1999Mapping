namespace _1999IdDump;
internal class Program
{
    static void Main(string[] args)
    {
        IdDump idDump = new IdDump();
        idDump.GenerateArcanistMap(@"ArcanistMap.json");
        idDump.GenerateGeneralMap(@"GeneralMap.json");
        idDump.GenerateStorySpriteMap(@"StorySpriteMap.json");
    }
    
}
