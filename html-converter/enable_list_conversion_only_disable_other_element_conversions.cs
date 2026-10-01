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
            // Prepare sample HTML file with a list
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><body><ul><li>Item 1</li><li>Item 2</li></ul></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Define output markdown file path
            string savePath = "output.md";

            // Configure Markdown save options to enable only list conversion
            MarkdownSaveOptions options = new MarkdownSaveOptions();
            options.Features = MarkdownFeatures.List;

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);

            Console.WriteLine("Conversion completed successfully. Markdown saved to: " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}