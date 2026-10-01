// Locate elements by class name and apply an internal CSS rule for background-color.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>First paragraph</p><p>Second paragraph</p></body></html>";

            // Load document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Change background color of all <p> elements
            Aspose.Html.Collections.NodeList paragraphs = document.QuerySelectorAll("p");
            foreach (Aspose.Html.HTMLElement p in paragraphs)
            {
                p.Style.BackgroundColor = "yellow";
            }

            // Ensure <head> exists
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Add a <style> element with CSS using HTMLStyleElement
            Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            string css = "p { font-weight: bold; }";
            Aspose.Html.Dom.Text cssNode = document.CreateTextNode(css);
            styleElement.AppendChild(cssNode);
            head.AppendChild(styleElement);

            // Add another <style> element using generic Element and TextContent
            Aspose.Html.Dom.Element genericStyle = document.CreateElement("style");
            genericStyle.TextContent = "body { background-color: #f0f0f0; }";
            head.AppendChild(genericStyle);

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"Document saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}