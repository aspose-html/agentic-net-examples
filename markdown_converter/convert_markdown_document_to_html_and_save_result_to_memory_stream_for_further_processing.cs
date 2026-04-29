// Convert a Markdown document to HTML and save the result to a memory stream for further processing.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Title\nThis is **bold** text in markdown.";

            // Convert markdown string to HTMLDocument
            using (MemoryStream markdownStream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                HTMLDocument document = Converter.ConvertMarkdown(markdownStream, "");

                // Save HTML to a memory stream
                MemoryStream htmlStream = new MemoryStream();
                using (StreamWriter writer = new StreamWriter(htmlStream, Encoding.UTF8, 1024, true))
                {
                    writer.Write(document.DocumentElement.OuterHTML);
                    writer.Flush();
                }
                htmlStream.Position = 0;

                // Example further processing: read the HTML string from the memory stream
                using (StreamReader reader = new StreamReader(htmlStream, Encoding.UTF8))
                {
                    string htmlContent = reader.ReadToEnd();
                    Console.WriteLine("Generated HTML:");
                    Console.WriteLine(htmlContent);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}