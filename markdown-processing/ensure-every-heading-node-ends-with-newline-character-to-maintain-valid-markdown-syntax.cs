// Ensure every heading node ends with a newline character to maintain valid Markdown syntax.

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
            string htmlContent = "<h1>Sample Heading</h1><p>This is a paragraph.</p>";
            string baseUri = "about:blank";

            // Paths for output files
            string htmlOutputPath = "output.html";
            string markdownOutputPath = "output.md";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            document.Save(htmlOutputPath);
            Console.WriteLine("HTML saved at " + Path.GetFullPath(htmlOutputPath));

            // Convert HTML to Markdown
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            string tempPath = Path.GetTempFileName();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);
            string markdown = File.ReadAllText(tempPath, Encoding.UTF8);
            File.Delete(tempPath);

            // Ensure heading ends with a newline (Markdown conversion already does this)
            if (!markdown.EndsWith("\n"))
            {
                markdown += "\n";
            }

            File.WriteAllText(markdownOutputPath, markdown, Encoding.UTF8);
            Console.WriteLine("Markdown saved at " + Path.GetFullPath(markdownOutputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}