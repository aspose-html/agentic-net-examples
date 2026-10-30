// Write a utility that reads Markdown from a stream and writes the HTML output to another stream.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Prepare output directory
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                Directory.CreateDirectory(outputDir);

                // Sample markdown content
                string markdown = "# Hello World\nThis is a **markdown** sample.";

                // Write markdown to a temporary file
                string markdownPath = Path.Combine(outputDir, "sample.md");
                File.WriteAllText(markdownPath, markdown, Encoding.UTF8);

                // Convert markdown file to HTMLDocument
                HTMLDocument htmlDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath);

                // Save HTMLDocument to an HTML file
                string htmlPath = Path.Combine(outputDir, "result.html");
                htmlDoc.Save(htmlPath);

                // Read and display the generated HTML (optional)
                string html = File.ReadAllText(htmlPath, Encoding.UTF8);
                Console.WriteLine(html);

                // Cleanup
                htmlDoc.Dispose();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}