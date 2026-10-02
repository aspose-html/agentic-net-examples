// Remove any embedded HTML tags from the Markdown content to ensure pure Markdown output.

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
            // Sample markdown content that includes embedded HTML tags
            string markdownWithHtml = "This is **bold** text.<br><p>Paragraph with <em>HTML</em> tags.</p>";

            // Base URI required by the converter (no relative resources in this example)
            string baseUri = "about:blank";

            // Options for converting HTML to Markdown
            MarkdownSaveOptions options = new MarkdownSaveOptions();

            // Temporary file to store the conversion result
            string tempPath = Path.GetTempFileName();

            // Convert the mixed content (treated as HTML) to pure Markdown
            Aspose.Html.Converters.Converter.ConvertHTML(markdownWithHtml, baseUri, options, tempPath);

            // Read the resulting pure Markdown
            string pureMarkdown = File.ReadAllText(tempPath);

            // Clean up the temporary file
            File.Delete(tempPath);

            // Output the cleaned Markdown
            Console.WriteLine("Pure Markdown output:");
            Console.WriteLine(pureMarkdown);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}