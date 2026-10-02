// Insert a custom script tag that logs page load time for performance monitoring.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            // Load HTML document from string
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Create a script element that logs page load time
            HTMLElement scriptElement = (HTMLElement)document.CreateElement("script");
            scriptElement.InnerHTML = "window.addEventListener('load', function(){ console.log('Page load time: ' + performance.now() + ' ms'); });";

            // Append the script to the body
            document.Body.AppendChild(scriptElement);

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