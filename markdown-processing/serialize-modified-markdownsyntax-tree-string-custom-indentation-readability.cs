// Serialize the modified MarkdownSyntaxTree to a string with custom indentation for readability.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Title</h1><p>This is a paragraph.</p></body></html>";
            string baseUri = "about:blank";

            // Configure Markdown save options
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();

            // Convert HTML to Markdown and save to a temporary file
            string tempPath = Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

            // Read the generated Markdown
            string markdown = File.ReadAllText(tempPath, Encoding.UTF8);
            File.Delete(tempPath);

            // Apply custom indentation for readability
            string indentedMarkdown = "  " + markdown.Replace("\n", "\n  ");

            // Output the result
            Console.WriteLine("Serialized Markdown with custom indentation:");
            Console.WriteLine(indentedMarkdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}