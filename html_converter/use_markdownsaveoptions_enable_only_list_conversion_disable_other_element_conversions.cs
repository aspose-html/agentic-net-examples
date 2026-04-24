// Use MarkdownSaveOptions to enable only list conversion while disabling other element conversions.

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
            string markdownPath = "output.md";

            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.List;

            Converter.ConvertHTML(htmlPath, options, markdownPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}