// Read a Markdown file into a stream, convert to HTML, and save the output to a target folder.

using System;
using System.IO;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourcePath = "input.md";
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(outputDir);
            string savePath = Path.Combine(outputDir, "output.html");
            Converter.ConvertMarkdown(sourcePath, savePath);
            Console.WriteLine("Conversion completed. HTML saved at " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}