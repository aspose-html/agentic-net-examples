// Locate elements by class name and apply an internal CSS rule for background-color.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with elements having class "highlight"
            string htmlContent = "<!DOCTYPE html><html><head></head><body><div class='highlight'>First</div><p class='highlight'>Second</p></body></html>";

            // Load the HTML document from the string (base URI is a placeholder)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Ensure there is a <head> element
            Aspose.Html.HTMLElement head = document.QuerySelector("head") as Aspose.Html.HTMLElement;
            if (head == null)
            {
                head = (Aspose.Html.HTMLElement)document.CreateElement("head");
                document.DocumentElement.InsertBefore(head, document.Body);
            }

            // Create a <style> element with the CSS rule for the target class
            Aspose.Html.HTMLStyleElement styleElement = (Aspose.Html.HTMLStyleElement)document.CreateElement("style");
            styleElement.TextContent = ".highlight { background-color: #FFCC00; }";

            // Append the style element to the head
            head.AppendChild(styleElement);

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}