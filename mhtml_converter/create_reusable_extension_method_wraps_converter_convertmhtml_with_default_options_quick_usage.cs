// Create a reusable extension method that wraps Converter.ConvertMHTML with default options for quick usage.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

static class MhtmlExtensions
{
    public static void ConvertToXps(this Stream stream, string outputPath)
    {
        XpsSaveOptions options = new XpsSaveOptions();
        Converter.ConvertMHTML(stream, options, outputPath);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mht";
            string outputPath = "output.xps";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                stream.ConvertToXps(outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}