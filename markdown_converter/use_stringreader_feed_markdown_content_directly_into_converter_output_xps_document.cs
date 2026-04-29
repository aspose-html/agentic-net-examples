// Use a StringReader to feed Markdown content directly into the converter and output an XPS document.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace MarkdownToXps
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Markdown content to be converted
                string markdown = "# Sample Title\nThis is a **markdown** document.";

                // Use StringReader to read the markdown string
                using (var stringReader = new StringReader(markdown))
                {
                    // Read all markdown text
                    string markdownText = stringReader.ReadToEnd();

                    // Convert the markdown text to a memory stream (UTF-8)
                    using (var markdownStream = new MemoryStream(Encoding.UTF8.GetBytes(markdownText)))
                    {
                        // Convert markdown stream to an HTMLDocument
                        using (HTMLDocument document = Converter.ConvertMarkdown(markdownStream, ""))
                        {
                            // Prepare XPS save options (default settings)
                            XpsSaveOptions options = new XpsSaveOptions();

                            // Define output XPS file path
                            string outputPath = "output.xps";

                            // Convert the HTMLDocument to XPS and save to the specified path
                            Converter.ConvertHTML(document, options, outputPath);
                        }
                    }
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}