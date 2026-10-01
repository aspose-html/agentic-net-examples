// Insert a custom script tag that logs page load time for performance monitoring.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories and file paths
            string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
            Directory.CreateDirectory(dataDir);
            string inputPath = Path.Combine(dataDir, "sample.html");
            string outputPath = Path.Combine(dataDir, "output.html");

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document with default configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration);

            // Create a custom script element that logs page load time
            Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)document.CreateElement("script");
            scriptElement.SetAttribute("type", "text/javascript");
            scriptElement.TextContent = "window.addEventListener('load', function(){ console.log('Page load time: ' + performance.now() + ' ms'); });";

            // Append the script to the document body
            Aspose.Html.Dom.Element body = (Aspose.Html.Dom.Element)document.Body;
            body.AppendChild(scriptElement);

            // Save the modified document
            document.Save(outputPath, new HTMLSaveOptions());

            Console.WriteLine("Document saved successfully to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}