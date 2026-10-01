// Detect the language attribute of the HTML tag and set it to “en‑US” if missing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content without language attribute
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello World</p></body></html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, string.Empty);

            // Get the <html> element(s)
            Aspose.Html.Collections.HTMLCollection htmlElements = document.GetElementsByTagName("html");

            for (int i = 0; i < htmlElements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)htmlElements[i];
                string lang = element.GetAttribute("lang");
                if (string.IsNullOrWhiteSpace(lang))
                {
                    element.SetAttribute("lang", "en-US");
                }
            }

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}