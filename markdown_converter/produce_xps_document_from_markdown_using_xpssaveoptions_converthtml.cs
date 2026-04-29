// Produce an XPS document from Markdown by supplying XpsSaveOptions to the ConvertHTML method.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MarkdownToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define source markdown file path
                string sourcePath = "sample.md";

                // Define markdown content
                string markdownContent = "# Hello World\nThis is a sample markdown file.";

                // Write markdown content to the source file
                File.WriteAllText(sourcePath, markdownContent);

                // Define output XPS file path
                string savePath = "output.xps";

                // Convert markdown file to an HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                // Initialize XPS save options with default settings
                XpsSaveOptions options = new XpsSaveOptions();

                // Convert the HTMLDocument to XPS format
                Converter.ConvertHTML(document, options, savePath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}