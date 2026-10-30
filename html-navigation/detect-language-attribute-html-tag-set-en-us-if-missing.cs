// Detect the language attribute of the HTML tag and set it to “en‑US” if missing.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><head><title>Test</title></head><body><p>Hello</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.HTMLCollection elements = document.GetElementsByTagName("html");
            for (int i = 0; i < elements.Length; i++)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)elements[i];
                string lang = element.GetAttribute("lang");
                if (string.IsNullOrWhiteSpace(lang))
                {
                    element.SetAttribute("lang", "en-US");
                }
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}