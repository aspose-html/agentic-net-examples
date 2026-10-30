// Define an internal CSS rule to set the body background-color for the entire page and save.

using System;
using System.IO;

namespace AsposeHtmlExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head></head><body></body></html>";
                var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                Aspose.Html.Dom.Element style = document.CreateElement("style");
                style.TextContent = "body { background-color: rgb(229, 243, 253) }";

                var headCollection = (Aspose.Html.Collections.HTMLCollection)document.GetElementsByTagName("head");
                if (headCollection.Length > 0)
                {
                    Aspose.Html.Dom.Element head = (Aspose.Html.Dom.Element)headCollection[0];
                    head.AppendChild(style);
                }

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);

                Console.WriteLine($"Document saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}