// Identify and list all external stylesheet URLs for dependency management in the project.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Css;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file to analyze
            string htmlPath = "input.html";

            // Load the HTML document; this will resolve external resources using the file's directory as base URI
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Access the collection of style sheets linked or embedded in the document
            IStyleSheetList styleSheets = document.StyleSheets;

            // Iterate through each style sheet and output its URL (href)
            for (int i = 0; i < styleSheets.Length; i++)
            {
                IStyleSheet sheet = styleSheets[i];
                // The Href property contains the URL of an external stylesheet; it may be null for inline styles
                string href = sheet.Href;
                if (!string.IsNullOrEmpty(href))
                {
                    Console.WriteLine(href);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}