// Convert a Markdown document to HTML and save the result to a memory stream for further processing.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = "# Sample Title\n\nThis is a **markdown** document.";

            // Create a memory stream from the markdown string
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));

            // Convert markdown to an HTMLDocument
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "");

            // Ensure the document has a <head> element
            Aspose.Html.Dom.Element head = document.QuerySelector("head");
            if (head == null)
            {
                head = (document.CreateElement("head")) as Aspose.Html.HTMLHeadElement;
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Get the generated HTML as a string
            string html = document.DocumentElement.OuterHTML;

            // Save the HTML string into a memory stream for further processing
            MemoryStream htmlStream = new MemoryStream(Encoding.UTF8.GetBytes(html));
            htmlStream.Position = 0; // Rewind the stream

            // Example usage: read the HTML back from the memory stream
            using (StreamReader reader = new StreamReader(htmlStream, Encoding.UTF8, true, 1024, true))
            {
                string result = reader.ReadToEnd();
                Console.WriteLine("Generated HTML:");
                Console.WriteLine(result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}