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
            string sourcePath;
            string outputPath;

            if (args.Length >= 2)
            {
                sourcePath = args[0];
                outputPath = args[1];
            }
            else
            {
                sourcePath = Path.Combine(Path.GetTempPath(), "sample.md");
                outputPath = Path.Combine(Path.GetTempPath(), "output.html");
                string sampleContent = "### Hello, World!\r\n[visit applications](https://products.aspose.app/html/family)";
                File.WriteAllText(sourcePath, sampleContent);
            }

            if (!File.Exists(sourcePath))
                throw new FileNotFoundException($"Source markdown file not found: {sourcePath}");

            Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath, outputPath);
            Console.WriteLine($"Conversion completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}