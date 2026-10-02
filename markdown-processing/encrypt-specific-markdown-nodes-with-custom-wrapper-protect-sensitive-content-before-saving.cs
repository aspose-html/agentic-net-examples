// Encrypt specific Markdown nodes using a custom wrapper to protect sensitive content before saving.

using System;
using System.IO;
using System.Text;
using Aspose.Html.Dom;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a node that needs protection
            string htmlContent = "<html><body>" +
                                 "<p class='secret'>Sensitive data that must be hidden</p>" +
                                 "<p>Public information</p>" +
                                 "</body></html>";

            // Load HTML from string (use two‑argument constructor)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find all <p> elements and encrypt those with class='secret'
            var paragraphs = document.GetElementsByTagName("p");
            foreach (var node in paragraphs)
            {
                var element = node as Aspose.Html.HTMLElement;
                if (element != null && element.GetAttribute("class") == "secret")
                {
                    string originalText = element.TextContent;
                    string encrypted = Convert.ToBase64String(Encoding.UTF8.GetBytes(originalText));
                    element.InnerHTML = $"<encrypted>{encrypted}</encrypted>";
                }
            }

            // Convert the modified HTML to Markdown
            string tempPath = Path.GetTempFileName();
            Aspose.Html.Saving.MarkdownSaveOptions options = new Aspose.Html.Saving.MarkdownSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, tempPath);

            // Read the generated Markdown
            string markdown = File.ReadAllText(tempPath);
            File.Delete(tempPath);

            // Save the Markdown to an output file
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.md");
            File.WriteAllText(outputPath, markdown);

            Console.WriteLine($"Markdown saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}