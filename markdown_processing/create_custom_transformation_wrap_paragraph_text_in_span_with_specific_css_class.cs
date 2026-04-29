// Create a custom transformation that wraps all paragraph text in a span with a specific CSS class.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = @"<html><head><title>Test</title></head><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>";
            string baseUri = "http://example.com/";

            // Load the HTML document from string
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Select all paragraph elements
            var paragraphs = document.QuerySelectorAll("p");

            // Wrap each paragraph's inner HTML with a span having a specific CSS class
            foreach (HTMLElement paragraph in paragraphs)
            {
                string original = paragraph.InnerHTML;
                paragraph.InnerHTML = $"<span class=\"myClass\">{original}</span>";
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}