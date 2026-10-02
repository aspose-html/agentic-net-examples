// Search for elements containing a specific keyword and highlight them by adding a CSS class.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><p>This is a sample with the keyword inside.</p><div>Another element without.</div><span>Another keyword occurrence.</span></body></html>";
            // Load HTML document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Define the keyword to search for
            string keyword = "keyword";

            // Select all elements in the document
            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("*");

            // Highlight elements containing the keyword
            foreach (Aspose.Html.HTMLElement element in elements)
            {
                if (!string.IsNullOrEmpty(element.InnerHTML) && element.InnerHTML.Contains(keyword))
                {
                    element.Style.BackgroundColor = "yellow";
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}