// Select the navigation menu using CSS selector "#nav" and set its font size to 16px.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><nav id=\"nav\">Menu</nav></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            var navElement = document.QuerySelector("#nav") as Aspose.Html.HTMLElement;
            if (navElement != null)
            {
                navElement.Style.SetProperty("font-size", "16px");
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