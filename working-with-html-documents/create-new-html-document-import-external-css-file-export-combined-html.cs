// Create a new HTML document, import an external CSS file, and export the combined result as HTML.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p class='msg'>Hello World</p></body></html>";

            // Prepare sample CSS content and write to a file
            string cssContent = ".msg { color: red; }";
            string cssFilePath = Path.Combine(Directory.GetCurrentDirectory(), "style.css");
            File.WriteAllText(cssFilePath, cssContent);

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the <head> element
            Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)document.GetElementsByTagName("head")[0];

            // Create a <link> element to import the external CSS file
            Aspose.Html.HTMLElement link = (Aspose.Html.HTMLElement)document.CreateElement("link");
            link.SetAttribute("rel", "stylesheet");
            link.SetAttribute("href", cssFilePath);

            // Append the <link> element to the <head>
            head.AppendChild(link);

            // Save the combined HTML document
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
            document.Save(outputPath);

            Console.WriteLine("HTML document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}