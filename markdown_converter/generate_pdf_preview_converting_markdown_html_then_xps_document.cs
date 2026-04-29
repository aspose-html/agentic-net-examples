// Generate a PDF preview by converting Markdown to HTML and then to an XPS document.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MarkdownToXpsDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define paths for the markdown source and the XPS output
                string sourcePath = "sample.md";
                string savePath = "output.xps";

                // Sample markdown content
                string markdownContent = "# Hello World\nThis is a **markdown** preview.";

                // Write the markdown content to a file
                File.WriteAllText(sourcePath, markdownContent);

                // Convert the markdown file to an HTMLDocument
                HTMLDocument document = Converter.ConvertMarkdown(sourcePath);

                // Prepare XPS save options (default settings)
                XpsSaveOptions options = new XpsSaveOptions();

                // Convert the HTMLDocument to an XPS file
                Converter.ConvertHTML(document, options, savePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}