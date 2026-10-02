// Write a utility that reads Markdown from a stream and writes the HTML output to another stream.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);

            // Sample markdown content
            string markdown = "# Hello World\nThis is a **markdown** sample.";

            // Write markdown to a temporary file
            string markdownPath = Path.Combine(outputDir, "sample.md");
            File.WriteAllText(markdownPath, markdown, Encoding.UTF8);

            // Define HTML output path
            string htmlPath = Path.Combine(outputDir, "output.html");

            // Convert markdown file to HTML file
            Aspose.Html.Converters.Converter.ConvertMarkdown(markdownPath, htmlPath);

            // Read and display the generated HTML
            string html = File.ReadAllText(htmlPath, Encoding.UTF8);
            Console.WriteLine("Conversion completed. HTML content:");
            Console.WriteLine(html);
            Console.WriteLine("HTML saved to: " + htmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}