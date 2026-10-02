// Use MarkdownSaveOptions to enable only list conversion while disabling other element conversions.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string savePath = "output.md";

            // Create a minimal HTML file with a list
            File.WriteAllText(htmlPath, "<html><body><ul><li>Item 1</li><li>Item 2</li></ul></body></html>");

            // Configure Markdown save options to enable only list conversion
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.List;

            // Perform the conversion
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);

            Console.WriteLine("Conversion completed. Markdown saved to " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}