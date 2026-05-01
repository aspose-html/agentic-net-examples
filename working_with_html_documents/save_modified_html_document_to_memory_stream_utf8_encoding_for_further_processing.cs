// Save a modified HTMLDocument to a MemoryStream with UTF‑8 encoding for further processing.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create an HTML document from a string (base URL is empty)
            string html = "<html><head><title>Test</title></head><body><p>Hello</p></body></html>";
            HTMLDocument document = new HTMLDocument(html, "");

            // Modify the document: add a new paragraph element
            Element newParagraph = document.CreateElement("p");
            newParagraph.TextContent = "Added paragraph";
            document.Body.AppendChild(newParagraph);

            // Serialize the modified document to UTF‑8 bytes
            string updatedHtml = document.DocumentElement.OuterHTML;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(updatedHtml);

            // Save the bytes into a MemoryStream for further processing
            using MemoryStream outputStream = new MemoryStream(bytes);
            Console.WriteLine($"Memory stream length: {outputStream.Length}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}