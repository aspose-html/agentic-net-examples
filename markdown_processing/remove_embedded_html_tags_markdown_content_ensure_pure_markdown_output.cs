// Remove any embedded HTML tags from the Markdown content to ensure pure Markdown output.

using System;
using System.IO;
using Aspose.Html;

namespace RemoveHtmlFromMarkdown
{
    class Program
    {
        static void Main()
        {
            try
            {
                string markdownWithHtml = "Your markdown **with** <b>HTML</b> tags.";
                string baseUri = "";
                HTMLDocument document = new HTMLDocument(markdownWithHtml, baseUri);
                string pureMarkdown = document.DocumentElement.TextContent;
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "clean.md");
                File.WriteAllText(outputPath, pureMarkdown);
                Console.WriteLine("Clean markdown saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}