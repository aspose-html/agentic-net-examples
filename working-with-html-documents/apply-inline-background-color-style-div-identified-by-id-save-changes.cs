// Apply an inline background-color style to a div identified by ID and save the changes.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a div having id="myDiv"
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><div id=\"myDiv\">Hello World</div></body></html>";

            // Load HTML from string using two-argument constructor (content, baseUri)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Find the div by ID
            Aspose.Html.Dom.Element element = document.QuerySelector("#myDiv");
            if (element != null && element is Aspose.Html.HTMLElement)
            {
                Aspose.Html.HTMLElement div = (Aspose.Html.HTMLElement)element;
                // Apply inline background-color style
                div.Style.BackgroundColor = "rgb(255,0,0)";
            }

            // Define output path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}