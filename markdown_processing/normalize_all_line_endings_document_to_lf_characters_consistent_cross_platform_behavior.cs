// Normalize all line endings in the document to LF characters for consistent cross‑platform behavior.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            string content = File.ReadAllText(inputPath);
            string normalized = content.Replace("\r\n", "\n").Replace("\r", "\n");
            File.WriteAllText(outputPath, normalized);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}