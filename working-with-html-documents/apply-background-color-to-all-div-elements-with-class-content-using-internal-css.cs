// Apply background-color to all div elements with class “content” using internal CSS.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body><div class=\"content\">Sample content</div></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Ensure <head> element exists
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Create <style> element with internal CSS
            Aspose.Html.Dom.Element style = document.CreateElement("style");
            style.TextContent = "div.content { background-color: #ffcc00; }";

            // Append style to head
            head.AppendChild(style);

            // Save the modified document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}