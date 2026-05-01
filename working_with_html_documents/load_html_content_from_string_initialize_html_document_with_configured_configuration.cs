// Load HTML content from a string and initialize an HTMLDocument with the configured Configuration.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><p>Hello, World!</p></body></html>";
            string baseUri = "http://example.com";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri, configuration);

            string outerHtml = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
            Console.WriteLine(outerHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}