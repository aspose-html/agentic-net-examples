// Convert Markdown to HTML, apply CSS styling, and then save the output as a PNG image.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Markdown content to be converted
            string markdown = "# Hello World\r\nThis is a **markdown** sample.";

            // Create a memory stream from the markdown string
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdown));

            // Convert markdown to an HTMLDocument
            HTMLDocument document = Converter.ConvertMarkdown(stream, "");

            // Ensure the document has a <head> element
            HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            // Create a <style> element with custom CSS
            HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
            styleElement.TextContent = "body { font-family: Arial; color: #333; }";

            // Append the style to the head
            head.AppendChild(styleElement);

            // Prepare image save options (defaults to PNG)
            ImageSaveOptions options = new ImageSaveOptions();

            // Output PNG path
            string pngPath = "output.png";

            // Render the HTMLDocument to a PNG image
            Converter.ConvertHTML(document, options, pngPath);

            Console.WriteLine("Conversion completed. PNG saved at " + pngPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}