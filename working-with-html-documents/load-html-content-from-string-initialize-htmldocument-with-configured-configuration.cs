// Load HTML content from a string and initialize an HTMLDocument with the configured Configuration.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Configure Aspose.HTML behavior
            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            config.Security |= Aspose.Html.Sandbox.Scripts;

            // HTML content to load
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, World!</h1></body></html>";
            string baseUri = "about:blank";

            // Initialize HTMLDocument with content and configuration
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri, config);

            // Output the document's outer HTML
            string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
            Console.WriteLine(outerHtml);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}