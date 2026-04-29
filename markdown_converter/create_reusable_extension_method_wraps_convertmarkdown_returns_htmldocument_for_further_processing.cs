// Create a reusable extension method that wraps ConvertMarkdown and returns an HTMLDocument for further processing.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;

namespace MarkdownToHtmlDemo
{
    // Extension methods for markdown conversion
    public static class MarkdownExtensions
    {
        // Converts a markdown string to an Aspose.HTMLDocument
        public static HTMLDocument ToHtmlDocument(this string markdown, string baseUri = "")
        {
            // Create a memory stream from the markdown string
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdown));
            // Convert the markdown stream to an HTMLDocument
            var document = Converter.ConvertMarkdown(stream, baseUri);
            return document;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Sample markdown content
                string markdown = "# Hello World\nThis is **bold** text.";
                // Use the extension method to get an HTMLDocument
                HTMLDocument htmlDoc = markdown.ToHtmlDocument();
                // Output the generated HTML
                Console.WriteLine(htmlDoc.DocumentElement.OuterHTML);
            }
            catch (Exception ex)
            {
                // Handle any conversion errors
                Console.WriteLine($"Conversion failed: {ex.Message}");
            }
        }
    }
}