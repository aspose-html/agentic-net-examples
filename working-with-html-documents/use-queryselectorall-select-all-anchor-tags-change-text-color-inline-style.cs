// Use QuerySelectorAll to select all anchor tags and change their text color via inline style.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><a href='https://example.com'>Link1</a> <a href='https://example.org'>Link2</a></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("a");
            foreach (HTMLElement element in elements)
            {
                element.Style.Color = "red";
            }

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