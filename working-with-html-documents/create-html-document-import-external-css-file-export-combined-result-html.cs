// Create a new HTML document, import an external CSS file, and export the combined result as HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string cssFilePath = Path.Combine(Directory.GetCurrentDirectory(), "style.css");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "combined.html");

            // Ensure CSS file exists
            if (!File.Exists(cssFilePath))
            {
                File.WriteAllText(cssFilePath, "h1 { color: red; }");
            }

            // Load CSS content
            string cssContent = File.ReadAllText(cssFilePath);

            // Create a new HTML document from inline content
            string htmlContent = "<!DOCTYPE html><html><head></head><body><h1>Hello World</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the <head> element
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];

            // Create a <style> element and set its content to the CSS
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = cssContent;

            // Append the <style> element to <head>
            head.AppendChild(style);

            // Save the combined HTML document
            document.Save(outputPath);

            System.Console.WriteLine("Combined HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}