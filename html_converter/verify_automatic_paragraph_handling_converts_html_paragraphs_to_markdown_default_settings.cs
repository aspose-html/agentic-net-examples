// Verify that automatic paragraph handling correctly converts HTML paragraphs to Markdown using default settings.

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
            // Define source HTML and target Markdown file paths
            string htmlPath = "sample.html";
            string markdownPath = "output.md";

            // Create a simple HTML file with paragraph elements
            string htmlContent = "<html><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Initialize default Markdown save options (automatic paragraph handling is enabled by default)
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Convert the HTML file to Markdown using Aspose.HTML
            Converter.ConvertHTML(htmlPath, options, markdownPath);

            // Read and display the resulting Markdown content
            string markdownResult = File.ReadAllText(markdownPath);
            Console.WriteLine("Converted Markdown:");
            Console.WriteLine(markdownResult);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}