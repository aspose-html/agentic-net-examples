// Enable inline HTML conversion together with default options to retain embedded HTML fragments in the Markdown output.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input HTML file and output Markdown file paths
            string htmlPath = "sample.html";
            string savePath = "output.md";

            // Create a minimal HTML file with inline HTML fragment
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello <span style=\"color:red;\">World</span></p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Initialize Markdown save options with default features
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            options.Features = Aspose.Html.Saving.MarkdownFeatures.Link | Aspose.Html.Saving.MarkdownFeatures.AutomaticParagraph;

            // Perform conversion from HTML to Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, savePath);

            Console.WriteLine("Conversion completed. Markdown saved at " + savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}