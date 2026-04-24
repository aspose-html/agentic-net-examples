// Convert an HTML string to a Markdown string by invoking the static Converter.ConvertHTML method.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToMarkdownExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // HTML content to convert
                string htmlContent = "<h1>Hello World</h1><p>This is a sample HTML.</p>";
                // Base URI (can be empty)
                string baseUri = "";
                // Options for markdown conversion
                MarkdownSaveOptions options = new MarkdownSaveOptions();
                // Temporary file to store markdown output
                string tempPath = Path.GetTempFileName();

                // Perform conversion: HTML string -> markdown file
                Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

                // Read markdown result
                string markdown = File.ReadAllText(tempPath);
                Console.WriteLine("Converted Markdown:");
                Console.WriteLine(markdown);

                // Clean up temporary file
                File.Delete(tempPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
        }
    }
}