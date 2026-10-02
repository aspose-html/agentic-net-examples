// Set border-color for all table elements using an internal CSS selector targeting table tags.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a table
            string htmlContent = "<!DOCTYPE html><html><head></head><body><table><tr><td>Cell</td></tr></table></body></html>";

            // Load HTML content using the two‑argument constructor (content, baseUri)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a <style> element and set internal CSS to style all table borders
            var styleElement = (Aspose.Html.HTMLElement)document.CreateElement("style");
            styleElement.InnerHTML = "table { border: 2px solid red; }";

            // Append the <style> element to the <head> section
            var head = (Aspose.Html.HTMLElement)document.QuerySelector("head");
            head.AppendChild(styleElement);

            // Save the modified document to a file
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}