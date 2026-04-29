// Replace all em dashes with double hyphens to ensure compatibility with plain‑text viewers.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputPath = "output.txt";
            string content = File.ReadAllText(inputPath);
            string result = content.Replace("—", "--");
            File.WriteAllText(outputPath, result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}