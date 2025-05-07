using System;
using System.IO;

namespace _1999IdDump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Check if a base path is provided
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: Reverse1999IdDump <OutputDirectory>");
                return;
            }
            try
            {
                // Initialize and generate maps
                IdDump idDump = new IdDump(args[0]);
                
                Console.WriteLine("Generating Arcanist Map...");
                idDump.GenerateArcanistMap();
                Console.WriteLine("Generating General Map...");
                idDump.GenerateGeneralMap();
                Console.WriteLine("Generating Story Sprite Map...");
                idDump.GenerateStorySpriteMap();
                Console.WriteLine("Done.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}