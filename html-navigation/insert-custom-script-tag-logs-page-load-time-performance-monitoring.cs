// Insert a custom script tag that logs page load time for performance monitoring.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load HTML document from string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a script element
            Aspose.Html.HTMLElement scriptElement = (Aspose.Html.HTMLElement)document.CreateElement("script");
            scriptElement.SetAttribute("type", "text/javascript");
            scriptElement.InnerHTML = "window.addEventListener('load', function(){ console.log('Page load time: ' + performance.now() + ' ms'); });";

            // Insert the script into the <head> if it exists, otherwise into <body>
            Aspose.Html.Collections.HTMLCollection headCollection = document.GetElementsByTagName("head");
            if (headCollection.Length > 0)
            {
                Aspose.Html.HTMLElement head = (Aspose.Html.HTMLElement)headCollection[0];
                head.AppendChild(scriptElement);
            }
            else
            {
                document.Body.AppendChild(scriptElement);
            }

            // Save the modified document to a file
            string outputPath = "output.html";
            Aspose.Html.Saving.HTMLSaveOptions saveOptions = new Aspose.Html.Saving.HTMLSaveOptions();
            document.Save(outputPath, saveOptions);

            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}