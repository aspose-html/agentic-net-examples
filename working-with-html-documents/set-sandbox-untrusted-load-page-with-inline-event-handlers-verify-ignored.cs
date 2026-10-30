// Set sandbox to untrusted, load a page with inline event handlers, and verify they are ignored.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body onload=\"document.getElementById('result').innerHTML='Loaded'\">" +
                                 "<div id=\"result\"></div>" +
                                 "</body></html>";

            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            Aspose.Html.Configuration config = new Aspose.Html.Configuration();
            // Untrusted sandbox (no script execution)
            config.Security = Aspose.Html.Sandbox.None;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, config))
            {
                var resultElement = document.GetElementById("result");
                string resultText = resultElement != null ? resultElement.TextContent : null;
                Console.WriteLine($"Result content: '{resultText}'");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}