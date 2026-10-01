// Optimize image markdown by adding width attributes to improve rendering performance on web pages.

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.md";
            string outputPath = "optimized.md";

            if (!File.Exists(inputPath))
            {
                string sampleContent = "Here is an image:\n\n![Sample Image](https://example.com/image.png)\n";
                File.WriteAllText(inputPath, sampleContent);
            }

            string markdown = File.ReadAllText(inputPath);

            string pattern = @"!\[([^\]]*)\]\(([^)]+)\)";
            string replacement = "<img src=\"$2\" alt=\"$1\" width=\"600\"/>";

            string optimizedMarkdown = Regex.Replace(markdown, pattern, replacement);

            File.WriteAllText(outputPath, optimizedMarkdown);

            Console.WriteLine("Optimized markdown saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}