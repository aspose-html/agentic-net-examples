// Write a utility that reads Markdown from a stream and writes the HTML output to another stream.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for demonstration; replace with your own streams as needed
            string inputPath = "input.md";
            string outputPath = "output.html";

            using (FileStream inputStream = File.OpenRead(inputPath))
            using (FileStream outputStream = File.Create(outputPath))
            {
                ConvertMarkdownToHtml(inputStream, outputStream);
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMarkdownToHtml(Stream markdownStream, Stream htmlStream)
    {
        // Convert the markdown stream to an HTMLDocument
        HTMLDocument document = Converter.ConvertMarkdown(markdownStream, string.Empty);

        // Retrieve the generated HTML as a string
        string html = document.DocumentElement.OuterHTML;

        // Write the HTML string to the output stream
        using (StreamWriter writer = new StreamWriter(htmlStream, System.Text.Encoding.UTF8, 1024, true))
        {
            writer.Write(html);
        }
    }
}