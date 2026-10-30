// Configure sandbox to limit script execution count, load a page with many scripts, and monitor limits.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and enable script sandboxing
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            // Set a JavaScript execution timeout (seconds)
            Aspose.Html.Services.IRuntimeService runtime = configuration.GetService<Aspose.Html.Services.IRuntimeService>();
            if (runtime != null)
            {
                runtime.JavaScriptTimeout = TimeSpan.FromSeconds(5);
            }

            // Prepare sample HTML with many scripts
            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<script>for(var i=0;i<1000000;i++){};</script>" +
                                 "<script>for(var i=0;i<1000000;i++){};</script>" +
                                 "<script>for(var i=0;i<1000000;i++){};</script>" +
                                 "</head><body><p>Sample page with many scripts.</p></body></html>";

            string tempFile = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(tempFile, htmlContent);

            // Load the document with the configured sandbox
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(tempFile, configuration))
            {
                string text = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                Console.WriteLine("Document text content:");
                Console.WriteLine(text);
            }

            // Clean up temporary file
            if (File.Exists(tempFile))
            {
                File.Delete(tempFile);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}