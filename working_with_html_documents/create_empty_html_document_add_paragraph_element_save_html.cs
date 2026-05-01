// Create an empty HTML document, add a paragraph element, and save it as HTML.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            HTMLDocument doc = new HTMLDocument();
            HTMLElement body = doc.Body;
            HTMLParagraphElement paragraph = (HTMLParagraphElement)doc.CreateElement("p");
            body.AppendChild(paragraph);
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}