// Add a language attribute to the html tag based on detected content language.

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
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello</p></body></html>";
            string baseUri = "http://example.com/";

            // Create HTMLDocument from content and base URI
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Detect language (placeholder logic)
            string detectedLanguage = "en";

            // Retrieve the <html> element
            var htmlElements = document.GetElementsByTagName("html");
            if (htmlElements.Length > 0)
            {
                // Cast to HTMLElement to access Lang property
                var htmlElement = (HTMLElement)htmlElements[0];
                // Set the language attribute
                htmlElement.Lang = detectedLanguage;
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}