// Add a language attribute to the html tag based on detected content language.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head><title>Sample</title></head><body>Hello world! Bonjour le monde!</body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Simple language detection
            string lang = "en";
            if (htmlContent.Contains("Bonjour"))
            {
                lang = "fr";
            }

            Aspose.Html.Collections.HTMLCollection htmlElements = document.GetElementsByTagName("html");
            if (htmlElements.Length > 0)
            {
                Aspose.Html.Dom.Element htmlElement = (Aspose.Html.Dom.Element)htmlElements[0];
                htmlElement.SetAttribute("lang", lang);
            }

            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"HTML saved to '{outputPath}' with lang attribute set to '{lang}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}