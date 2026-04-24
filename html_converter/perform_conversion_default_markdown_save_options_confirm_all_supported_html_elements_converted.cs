// Perform conversion with default MarkdownSaveOptions and confirm that all supported HTML elements are converted.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string mdPath = "output.md";
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            Converter.ConvertHTML(htmlPath, options, mdPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}