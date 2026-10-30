// Create a reusable extension method that wraps Converter.ConvertMHTML with default options for quick usage.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.mhtml";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            inputPath.ConvertToMhtml(outputPath);
            Console.WriteLine($"MHTML file created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

static class HTMLConversionExtensions
{
    public static void ConvertToMhtml(this string sourcePath, string outputPath)
    {
        var options = new Aspose.Html.Saving.MHTMLSaveOptions();
        Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, options, outputPath);
    }
}