// Enable inline HTML element conversion by setting the appropriate feature flag in MarkdownSaveOptions.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string savePath = "output.md";

            // Create a minimal HTML file with inline HTML elements if it doesn't exist
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><p>Paragraph with <span style=\"color:red;\">inline <b>HTML</b></span> element.</p></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            MarkdownSaveOptions options = new MarkdownSaveOptions();
            // Enable link, automatic paragraph, and inline HTML conversion (using the underlying flag value)
            options.Features = MarkdownFeatures.Link | MarkdownFeatures.AutomaticParagraph | (MarkdownFeatures)0x4;

            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);

            Console.WriteLine("Conversion completed. Markdown saved at " + Path.GetFullPath(savePath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}