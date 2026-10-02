// Create a command‑line tool that accepts input Markdown path and output format arguments for conversion.

using System;
using System.IO;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = args.Length > 0 ? args[0] : "sample.md";
            string outputPath = args.Length > 1 ? args[1] : "output.html";

            if (!File.Exists(sourcePath))
            {
                string sampleContent = "# Sample Markdown\r\n\r\nThis is a *sample* markdown file.";
                File.WriteAllText(sourcePath, sampleContent);
            }

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, outputPath);
            Console.WriteLine($"Markdown converted successfully. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}