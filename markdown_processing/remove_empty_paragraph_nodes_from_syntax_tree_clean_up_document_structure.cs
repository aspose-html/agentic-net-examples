// Remove all empty paragraph nodes from the syntax tree to clean up the document structure.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with empty and non‑empty paragraphs
            string html = @"
                <html>
                    <body>
                        <p>First paragraph.</p>
                        <p>   </p>
                        <p></p>
                        <p>Second paragraph.</p>
                    </body>
                </html>";
            string baseUri = "http://example.com";

            // Create an HTMLDocument from the string content
            HTMLDocument document = new HTMLDocument(html, baseUri);

            // Select all paragraph elements
            var paragraphs = document.QuerySelectorAll("p");

            // Remove paragraphs that are empty or contain only whitespace
            foreach (Aspose.Html.HTMLElement p in paragraphs)
            {
                if (string.IsNullOrWhiteSpace(p.InnerHTML))
                {
                    p.ParentNode.RemoveChild(p);
                }
            }

            // Save the cleaned document
            string outputPath = "cleaned.html";
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}