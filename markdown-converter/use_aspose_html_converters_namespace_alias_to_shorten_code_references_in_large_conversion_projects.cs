// Use the Aspose.Html.Converters namespace alias to shorten code references in large conversion projects.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.md";
            string outputPath = "output.html";

            // Create a minimal markdown file
            File.WriteAllText(sourcePath, "# Hello Aspose\nThis is a sample markdown file.");

            // Convert markdown to HTML using fully qualified Aspose.Html.Converters API
            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, outputPath);

            Console.WriteLine($"Conversion completed. Output saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}