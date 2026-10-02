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
            string markdown = "# Sample Title\n\nThis is a **markdown** document.";
            // Load markdown into a memory stream
            using (MemoryStream markdownStream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                // Convert markdown to HTMLDocument
                using (HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(markdownStream, "about:blank"))
                {
                    // Get the generated HTML as a string
                    string html = document.DocumentElement.OuterHTML;
                    // Save HTML to a memory stream
                    MemoryStream htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(html));
                    // Rewind the stream for further processing
                    htmlStream.Position = 0;
                    // Example processing: read and output the HTML
                    using (StreamReader reader = new StreamReader(htmlStream, Encoding.UTF8, true, 1024, leaveOpen: true))
                    {
                        string result = reader.ReadToEnd();
                        Console.WriteLine(result);
                    }
                    // Dispose the HTML memory stream when done
                    htmlStream.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}