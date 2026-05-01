// Convert a template with embedded SVG graphics to HTML and render it to PNG preserving vector quality.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = @"<html><body><svg width='200' height='200'><rect width='200' height='200' style='fill:blue;stroke-width:3;stroke:rgb(0,0,0)'/></svg></body></html>";
            string baseUri = AppDomain.CurrentDomain.BaseDirectory;
            ImageSaveOptions options = new ImageSaveOptions();
            string outputPath = "output.png";
            Converter.ConvertHTML(htmlContent, baseUri, options, outputPath);
            Console.WriteLine("HTML rendered to PNG successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}