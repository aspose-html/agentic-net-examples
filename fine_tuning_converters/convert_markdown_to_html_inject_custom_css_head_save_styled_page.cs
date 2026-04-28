// Convert a Markdown string to HTML, inject custom CSS into the head, and save the styled page.

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
            // Markdown content to be converted
            string markdown = "# Hello World\nThis is a **markdown** text.";

            // Create a memory stream from the markdown string
            var stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(markdown));

            // Convert markdown to an HTMLDocument (base URI is empty)
            HTMLDocument document = Converter.ConvertMarkdown(stream, string.Empty);

            // Retrieve the <head> element; create it if it does not exist
            HTMLHeadElement head = document.QuerySelector("head") as HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            // Create a <style> element and set custom CSS
            HTMLStyleElement styleElement = document.CreateElement("style") as HTMLStyleElement;
            styleElement.TextContent = "body { font-family: Arial; color: #333; }";

            // Append the style element to the head
            head.AppendChild(styleElement);

            // Save the styled HTML to a file
            string outputPath = "styled.html";
            document.Save(outputPath);

            // Output the resulting HTML and a completion message
            Console.WriteLine(document.DocumentElement.OuterHTML);
            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}