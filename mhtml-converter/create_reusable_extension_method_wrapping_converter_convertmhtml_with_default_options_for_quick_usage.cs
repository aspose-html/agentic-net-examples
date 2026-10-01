// Create a reusable extension method that wraps Converter.ConvertMHTML with default options for quick usage.

using System;
using System.IO;

static class HtmlConversionExtensions
{
    public static void ConvertMhtml(this string inputPath, string outputPath)
    {
        var options = new Aspose.Html.Saving.XpsSaveOptions();
        Aspose.Html.Converters.Converter.ConvertMHTML(inputPath, options, outputPath);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            File.WriteAllText(inputPath, "<html><body><h1>Sample</h1></body></html>");

            string outputPath = "output.xps";

            inputPath.ConvertMhtml(outputPath);

            Console.WriteLine($"MHTML converted to XPS: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}