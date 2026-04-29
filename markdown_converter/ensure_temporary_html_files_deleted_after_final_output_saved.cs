// Ensure that temporary HTML files created during conversion are deleted after the final output is saved.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace AsposeHtmlTempFileCleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // HTML content to be converted
                string htmlContent = "<html><body><h1>Hello, World!</h1></body></html>";
                // Base URI for resolving relative resources (if any)
                string baseUri = "http://example.com";

                // Options for Markdown conversion
                MarkdownSaveOptions options = new MarkdownSaveOptions();

                // Create a temporary file path for the conversion output
                string tempPath = Path.GetTempFileName();

                // Perform conversion: HTML -> Markdown, output written to temporary file
                Converter.ConvertHTML(htmlContent, baseUri, options, tempPath);

                // Read the generated Markdown content
                string markdown = File.ReadAllText(tempPath);
                Console.WriteLine("Converted Markdown:");
                Console.WriteLine(markdown);

                // Delete the temporary file to clean up resources
                File.Delete(tempPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}