// Set a CSS background-image rule for the body element using a remote image URL.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Dom.Element bodyElement = document.QuerySelector("body");
            if (bodyElement != null)
            {
                bodyElement.SetAttribute("style", "background-image: url('https://example.com/flower.png');");
            }

            string outputPath = "output.html";
            document.Save(outputPath);
            Console.WriteLine($"HTML saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}