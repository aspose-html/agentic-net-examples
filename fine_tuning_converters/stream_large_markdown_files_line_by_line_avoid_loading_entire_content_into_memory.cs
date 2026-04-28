// Stream large Markdown files line by line into ConvertMarkdown to avoid loading the entire content into memory.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.md";
            string outputPath = "output.html";
            using (FileStream stream = File.OpenRead(inputPath))
            {
                HTMLDocument document = Converter.ConvertMarkdown(stream, string.Empty);
                document.Save(outputPath);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}